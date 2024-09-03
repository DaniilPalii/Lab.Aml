namespace Lab.Aml.Domain.Customers.Commands.Update;

public interface IUpdateCustomerRepository
{
	Task UpdateAsync(UpdateCustomerCommand customer, CancellationToken cancellationToken);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
