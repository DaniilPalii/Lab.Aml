namespace Lab.Aml.Domain.Customers.Queries.GetAll;

public interface IGetCustomersRepository
{
	Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
}
