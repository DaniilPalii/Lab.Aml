namespace Lab.Aml.Domain.Transactions.Queries.GetById;

public interface IGetTransactionByIdRepository
{
	Task<Transaction?> GetByIdAsync(long id, CancellationToken cancellationToken);
}
