using Lab.Aml.DataPersistence.Context;
using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Add;
using Lab.Aml.Domain.Transactions.Commands.Delete;
using Lab.Aml.Domain.Transactions.Commands.Update;
using Lab.Aml.Domain.Transactions.Queries.Get;
using Lab.Aml.Domain.Transactions.Queries.GetById;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Repositories;

public sealed class TransactionRepository(AppDbContext dbContext)
	: IAddTransactionRepository,
		IGetTransactionsRepository,
		IGetTransactionByIdRepository,
		IUpdateTransactionRepository,
		IDeleteTransactionRepository
{
	public void Add(AddTransactionCommand transaction)
	{
		dbContext.Transactions.Add(
			new Entities.Transaction
			{
				Amount = transaction.Amount,
				Currency = transaction.Currency,
				CreationDate = transaction.CreationDate,
				TransactionType = transaction.TransactionType,
				CustomerId = transaction.CustomerId,
				Description = transaction.Description,
			});
	}

	public async Task<IEnumerable<Transaction>> GetAsync(
		CancellationToken cancellationToken,
		long? customerId = null)
	{
		var query = customerId is not null
			? dbContext.Transactions.Where(t => t.CustomerId == customerId)
			: dbContext.Transactions.AsQueryable();

		return await query
			.Select(t => t.ToDomainValue())
			.ToListAsync(cancellationToken);
	}

	public async Task<Transaction?> GetByIdAsync(long id, CancellationToken cancellationToken)
	{
		return await dbContext.Transactions
			.Where(t => t.Id == id)
			.Select(t => t.ToDomainValue())
			.FirstOrDefaultAsync(cancellationToken);
	}

	public void Update(UpdateTransactionCommand transaction)
	{
		dbContext.Transactions.Update(
			new Entities.Transaction
			{
				Id = transaction.Id,
				Amount = transaction.Amount,
				Currency = transaction.Currency,
				CreationDate = transaction.CreationDate,
				TransactionType = transaction.TransactionType,
				CustomerId = transaction.CustomerId,
				Description = transaction.Description,
			});
	}

	public void Delete(long id)
	{
		dbContext.Transactions.Remove(new Entities.Transaction { Id = id });
	}

	public async Task SaveChangesAsync(CancellationToken cancellationToken)
	{
		await dbContext.SaveChangesAsync(cancellationToken);
	}
}
