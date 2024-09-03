namespace Lab.Aml.Domain.Transactions.Commands.Delete;

public interface IDeleteTransactionRepository
{
	Task DeleteAsync(long id, CancellationToken cancellationToken);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
