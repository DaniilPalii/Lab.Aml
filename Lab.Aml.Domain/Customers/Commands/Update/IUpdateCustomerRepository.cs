namespace Lab.Aml.Domain.Customers.Commands.Update;

public interface IUpdateCustomerRepository
{
	void Update(UpdateCustomerCommand customer);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
