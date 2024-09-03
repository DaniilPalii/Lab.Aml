namespace Lab.Aml.Domain.Customers.Queries.Get;

public interface IGetCustomersRepository
{
	Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
}
