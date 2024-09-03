namespace Lab.Aml.Domain.Transactions.Commands.Update;

public interface IUpdateTransactionRepository
{
	Task UpdateAsync(UpdateTransactionCommand customer, CancellationToken cancellationToken);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
