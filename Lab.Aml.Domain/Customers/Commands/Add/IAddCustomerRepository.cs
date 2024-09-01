namespace Lab.Aml.Domain.Customers.Commands.Add;

public interface IAddCustomerRepository
{
	void Add(AddCustomerCommand customer);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
