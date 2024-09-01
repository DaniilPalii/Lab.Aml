namespace Lab.Aml.Domain.Customers.Queries.GetById;

public interface IGetCustomerByIdRepository
{
	Task<Customer?> GetByIdAsync(long id, CancellationToken cancellationToken);
}
