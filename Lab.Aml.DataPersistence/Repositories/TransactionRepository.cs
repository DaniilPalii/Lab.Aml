using Lab.Aml.DataPersistence.Context;
using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Add;
using Lab.Aml.Domain.Transactions.Commands.Delete;
using Lab.Aml.Domain.Transactions.Commands.Update;
using Lab.Aml.Domain.Transactions.Commands.Verify;
using Lab.Aml.Domain.Transactions.Queries.Get;
using Lab.Aml.Domain.Transactions.Queries.GetById;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Repositories;

public sealed class TransactionRepository(AppDbContext dbContext)
	: IAddTransactionRepository,
		IGetTransactionsRepository,
		IGetTransactionByIdRepository,
		IUpdateTransactionRepository,
		IDeleteTransactionRepository,
		IVerifyTransactionsRepository
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

	public async Task<List<Transaction>> GetNotVerifiedAsync(CancellationToken cancellationToken)
	{
		return await dbContext.Transactions
			.Where(t => t.IsSuspicious == null)
			.Select(t => t.ToDomainValue()) // TODO: make projections smaller and specified per caller
			.ToListAsync(cancellationToken);
	}

	public async Task<IEnumerable<Transaction>> GetByIdWithPreviousAndNextAsync(
		long id,
		int previousOrNextTransactionsCount,
		CancellationToken cancellationToken)
	{
		var targetTransaction = await dbContext.Transactions
			.Where(t => t.Id == id)
			.Select(t => t.ToDomainValue())
			.FirstOrDefaultAsync(cancellationToken);

		if (targetTransaction == null)
			return [];

		var previousTransactions = await dbContext.Transactions
			.Where(t => t.CustomerId == targetTransaction.CustomerId
				&& t.CreationDate < targetTransaction.CreationDate)
			.OrderByDescending(t => t.CreationDate)
			.Take(previousOrNextTransactionsCount)
			.Select(t => t.ToDomainValue())
			.ToListAsync(cancellationToken);

		var nextTransactions = await dbContext.Transactions
			.Where(t => t.CustomerId == targetTransaction.CustomerId
				&& t.CreationDate >= targetTransaction.CreationDate
				&& t.Id != id)
			.OrderByDescending(t => t.CreationDate)
			.Take(previousOrNextTransactionsCount)
			.Select(t => t.ToDomainValue())
			.ToListAsync(cancellationToken);

		return previousTransactions
			.Concat([targetTransaction])
			.Concat(nextTransactions);
	}

	public void MarkAsNotSuspicious(long id)
	{
		SetSuspicion(id, isSuspicious: false);
	}

	public void MarkAsSuspicious(long id)
	{
		SetSuspicion(id, isSuspicious: true);
	}

	public async Task SaveChangesAsync(CancellationToken cancellationToken)
	{
		await dbContext.SaveChangesAsync(cancellationToken);
	}

	private void SetSuspicion(long id, bool isSuspicious)
	{
		var transaction = new Entities.Transaction
		{
			Id = id,
			IsSuspicious = isSuspicious,
		};

		dbContext.Attach(transaction);
		dbContext.Entry(transaction).Property(e => e.IsSuspicious).IsModified = true;
	}
}
