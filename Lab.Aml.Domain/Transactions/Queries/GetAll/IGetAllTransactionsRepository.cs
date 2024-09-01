namespace Lab.Aml.Domain.Transactions.Queries.GetAll;

public interface IGetAllTransactionsRepository
{
	Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken cancellationToken);
}
