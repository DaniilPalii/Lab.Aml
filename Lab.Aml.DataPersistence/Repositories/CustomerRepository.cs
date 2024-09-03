using Lab.Aml.DataPersistence.Context;
using Lab.Aml.Domain.Customers;
using Lab.Aml.Domain.Customers.Commands.Add;
using Lab.Aml.Domain.Customers.Commands.Delete;
using Lab.Aml.Domain.Customers.Commands.Update;
using Lab.Aml.Domain.Customers.Queries.Get;
using Lab.Aml.Domain.Customers.Queries.GetById;
using Lab.Aml.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Repositories;

public sealed class CustomerRepository(AppDbContext dbContext)
	: IAddCustomerRepository,
		IGetCustomersRepository,
		IGetCustomerByIdRepository,
		IUpdateCustomerRepository,
		IDeleteCustomerRepository
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

	public async Task<List<Customer>> GetAsync(GetCustomersQuery query, CancellationToken cancellationToken)
	{
		var queryable = dbContext.Customers.AsQueryable();

		if (query.Name is not null)
			queryable = queryable.Where(c => c.Name == query.Name);

		if (query.Surname is not null)
			queryable = queryable.Where(c => c.Surname == query.Surname);

		return await queryable
			.Select(e => e.ToDomainValue())
			.ToListAsync(cancellationToken);
	}

	public async Task<Customer?> GetByIdAsync(long id, CancellationToken cancellationToken)
	{
		return await dbContext.Customers
			.Where(e => e.Id == id)
			.Select(e => e.ToDomainValue())
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task UpdateAsync(UpdateCustomerCommand customer, CancellationToken cancellationToken)
	{
		await EnsureCustomerExistsAsync(customer.Id, cancellationToken);

		dbContext.Customers.Update(
			new Entities.Customer
			{
				Id = customer.Id,
				Name = customer.Name,
				Surname = customer.Surname,
				Birthdate = customer.Birthdate,
				Address = customer.Address,
			});
	}

	public async Task DeleteAsync(long id, CancellationToken cancellationToken)
	{
		await EnsureCustomerExistsAsync(id, cancellationToken);

		dbContext.Customers.Remove(new Entities.Customer { Id = id });
	}

	public async Task SaveChangesAsync(CancellationToken cancellationToken)
	{
		await dbContext.SaveChangesAsync(cancellationToken);
	}

	private async Task EnsureCustomerExistsAsync(long customerId, CancellationToken cancellationToken)
	{
		if (await dbContext.Transactions
			.Where(t => t.Id == customerId)
			.FirstOrDefaultAsync(cancellationToken)
			is null)
			throw new NotFoundException($"Customer with ID {customerId} doesn't exists.");
	}
}
