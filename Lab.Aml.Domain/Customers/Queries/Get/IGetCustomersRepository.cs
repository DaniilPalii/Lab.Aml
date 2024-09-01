namespace Lab.Aml.Domain.Customers.Queries.Get;

public interface IGetCustomersRepository
{
	Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
}
