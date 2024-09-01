﻿using Lab.Aml.DataPersistence.Context;
using Lab.Aml.Domain.Customers;
using Lab.Aml.Domain.Customers.Commands.Add;
using Lab.Aml.Domain.Customers.Commands.Delete;
using Lab.Aml.Domain.Customers.Commands.Update;
using Lab.Aml.Domain.Customers.Queries.GetAll;
using Lab.Aml.Domain.Customers.Queries.GetById;
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

	public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await dbContext.Customers
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

	public void Update(UpdateCustomerCommand customer)
	{
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

	public void Delete(long id)
	{
		dbContext.Customers.Remove(new Entities.Customer { Id = id });
	}

	public async Task SaveChangesAsync(CancellationToken cancellationToken)
	{
		await dbContext.SaveChangesAsync(cancellationToken);
	}
}
