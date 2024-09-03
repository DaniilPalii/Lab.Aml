namespace Lab.Aml.Domain.Transactions.Commands.Verify;

public interface IVerifyTransactionsRepository
{
	Task<List<Transaction>> GetNotVerifiedAsync(CancellationToken cancellationToken);

	Task<IEnumerable<Transaction>> GetByIdWithPreviousAndNextAsync(
		long id,
		int previousOrNextTransactionsCount,
		CancellationToken cancellationToken);

	void MarkAsNotSuspicious(long id);

	void MarkAsSuspicious(long id);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
