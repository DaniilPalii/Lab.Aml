using Lab.Aml.DataPersistence.Context;
using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Add;
using Lab.Aml.Domain.Transactions.Commands.Delete;
using Lab.Aml.Domain.Transactions.Commands.Update;
using Lab.Aml.Domain.Transactions.Queries.GetAll;
using Lab.Aml.Domain.Transactions.Queries.GetById;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Repositories;

public sealed class TransactionRepository(AppDbContext dbContext)
	: IAddTransactionRepository,
		IGetAllTransactionsRepository,
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
				CustomerId = transaction.CustomerId,
				Description = transaction.Description,
			});
	}

	public async Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await dbContext.Transactions
			.Select(e => e.ToDomainValue())
			.ToListAsync(cancellationToken);
	}

	public async Task<Transaction?> GetByIdAsync(long id, CancellationToken cancellationToken)
	{
		return await dbContext.Transactions
			.Where(e => e.Id == id)
			.Select(e => e.ToDomainValue())
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
