namespace Lab.Aml.Domain.Customers.Queries.GetAll;

public interface IGetAllCustomersRepository
{
	Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
}
