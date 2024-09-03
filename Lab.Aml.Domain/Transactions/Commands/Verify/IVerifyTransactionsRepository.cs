namespace Lab.Aml.Domain.Transactions.Commands.Verify;

public interface IVerifyTransactionsRepository
{
	Task<List<Transaction>> GetNotVerifiedAsync(CancellationToken cancellationToken);

	Task<IEnumerable<Transaction>> GetByIdWithPreviousAndNextAsync(
		long id,
		int previousOrNextTransactionsCount,
		CancellationToken cancellationToken);

	void SetSuspicion(long id, bool isSuspicious);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
