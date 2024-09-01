namespace Lab.Aml.Domain.Customers.Commands.Delete;

public interface IDeleteCustomerRepository
{
	public void Delete(long id);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
