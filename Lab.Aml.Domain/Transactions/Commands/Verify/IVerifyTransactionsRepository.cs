namespace Lab.Aml.Domain.Transactions.Commands.Verify;

public interface IVerifyTransactionsRepository
{
	Task<List<Transaction>> GetNotVerifiedAsync(CancellationToken cancellationToken);

	Task<IEnumerable<Transaction>> GetByIdWithPreviousAndNextAsync(
		long id,
		int previousOrNextTransactionsCount,
		CancellationToken cancellationToken);

	Task SetSuspicionAsync(long id, bool isSuspicious, CancellationToken cancellationToken);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
