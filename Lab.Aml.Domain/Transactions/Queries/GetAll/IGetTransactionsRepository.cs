namespace Lab.Aml.Domain.Transactions.Queries.GetAll;

public interface IGetTransactionsRepository
{
	Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken cancellationToken);
}
