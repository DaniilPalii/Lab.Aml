namespace Lab.Aml.Domain.Transactions.Queries.Get;

public interface IGetTransactionsRepository
{
	Task<IEnumerable<Transaction>> GetAsync(
		CancellationToken cancellationToken,
		long? CustomerId = null);
}
