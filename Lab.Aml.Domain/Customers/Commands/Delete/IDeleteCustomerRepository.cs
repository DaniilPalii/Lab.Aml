namespace Lab.Aml.Domain.Customers.Commands.Delete;

public interface IDeleteCustomerRepository
{
	Task DeleteAsync(long id, CancellationToken cancellationToken);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
