namespace Lab.Aml.Domain.Customers.Queries.Get;

public interface IGetCustomersRepository
{
	Task<List<Customer>> GetAsync(GetCustomersQuery query, CancellationToken cancellationToken);
}
