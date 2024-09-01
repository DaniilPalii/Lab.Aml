using Lab.Aml.DataPersistence.Context;
using Lab.Aml.Domain.Customers;
using Lab.Aml.Domain.Customers.Commands.Add;
using Lab.Aml.Domain.Customers.Queries.GetAll;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Repositories;

public class CustomerRepository(AppDbContext dbContext)
	: IAddCustomerRepository,
		IGetAllCustomersRepository
{
	public void Add(AddCustomerCommand customer)
	{
		dbContext.Customers.Add(
			new Entities.Customer
			{
				Name = customer.Name,
				Surname = customer.Surname,
				Birthdate = customer.Birthdate,
				Address = customer.Address,
			});
	}

	public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await dbContext.Customers
			.Select(e => e.ToDomainValue())
			.ToListAsync(cancellationToken);
	}

	public async Task SaveChangesAsync(CancellationToken cancellationToken)
	{
		await dbContext.SaveChangesAsync(cancellationToken);
	}
}
