namespace Lab.Aml.Domain.Transactions.Commands.Update;

public interface IUpdateTransactionRepository
{
	void Update(UpdateTransactionCommand customer);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
