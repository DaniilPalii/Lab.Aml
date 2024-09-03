using System.Diagnostics.CodeAnalysis;
using Lab.Aml.Domain.Limits;
using Lab.Aml.Domain.Limits.Queries.GetLatest;
using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Verify;

public sealed class VerifyTransactionsCommandHandler(
	IVerifyTransactionsRepository repository,
	IMediator mediator)
	: IRequestHandler<VerifyTransactionsCommand>
{
	public async Task Handle(VerifyTransactionsCommand request, CancellationToken cancellationToken)
	{
		// The validation here optimized for transactions that could be added for dates in past.
		// If transacations will be added only for present moment, then the valition should be adjusted.

		var limitsByCurrency = (await mediator.Send(new GetLatestLimitsQuery(), cancellationToken))
			.ToDictionary(l => l.Currency);

		var transactionsToVerify = await repository.GetNotVerifiedAsync(cancellationToken);
		var suspiciousTransactionIds = new HashSet<long>();

		foreach (var transaction in transactionsToVerify)
		{
			var limit = limitsByCurrency[transaction.Currency];
			var transactionsToVerifyFrequency = await repository.GetByIdWithPreviousAndNextAsync(
				transaction.Id,
				previousOrNextTransactionsCount: limit.Count - 1,
				cancellationToken);

			if (TryGetTooFrequentTransactions(transactionsToVerifyFrequency, limit, out var tooFrequentTransactions))
			{
				foreach (var tooFrequentTransaction in tooFrequentTransactions)
					suspiciousTransactionIds.Add(tooFrequentTransaction.Id);
			}
			else if (transaction.Amount > limit.Amount)
			{
				suspiciousTransactionIds.Add(transaction.Id);
			}
		}

		foreach (var transaction in transactionsToVerify)
		{
			var isSuspicious = suspiciousTransactionIds.Contains(transaction.Id);
			repository.SetSuspicion(transaction.Id, isSuspicious);
		}

		await repository.SaveChangesAsync(cancellationToken);
	}

	private static bool TryGetTooFrequentTransactions(
		IEnumerable<Transaction> transactions,
		Limit limit,
		[NotNullWhen(true)] out IEnumerable<Transaction> tooFrequentTransactions)
	{
		tooFrequentTransactions = null!;

		var orderedTransactions = transactions.OrderBy(t => t.CreationDate).ToList();

		if (orderedTransactions.Count < limit.Count)
			return false;

		for (var (start, end) = (0, limit.Count - 1);
			end < orderedTransactions.Count;
			start++, end++)
		{
			var range = orderedTransactions[start].CreationDate - orderedTransactions[end].CreationDate;

			if (range < limit.Range)
			{
				tooFrequentTransactions = orderedTransactions[start..(end + 1)];
				return true;
			}
		}

		return false;
	}
}
