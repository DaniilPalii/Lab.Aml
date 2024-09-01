namespace Lab.Aml.Domain.Transactions.Commands.Add;

public interface IAddTransactionRepository
{
	void Add(AddTransactionCommand customer);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
