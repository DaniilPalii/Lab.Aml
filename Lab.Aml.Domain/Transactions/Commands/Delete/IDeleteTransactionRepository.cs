namespace Lab.Aml.Domain.Transactions.Commands.Delete;

public interface IDeleteTransactionRepository
{
	public void Delete(long id);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
