namespace Lab.Aml.Domain.Customers.Commands.Add;

public interface IUpdateCustomerRepository
{
	void Update(UpdateCustomerCommand customer);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
