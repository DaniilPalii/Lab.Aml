namespace Lab.Aml.Domain.Transactions.Queries.Get;

public interface IGetTransactionsRepository
{
	Task<IEnumerable<Transaction>> GetAsync(
		GetTransactionsQuery query,
		CancellationToken cancellationToken);
}
