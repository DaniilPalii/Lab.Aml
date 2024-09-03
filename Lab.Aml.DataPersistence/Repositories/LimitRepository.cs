using Lab.Aml.DataPersistence.Context;
using Lab.Aml.Domain.Limits;
using Lab.Aml.Domain.Limits.Commands.Add;
using Lab.Aml.Domain.Limits.Queries.GetHistory;
using Lab.Aml.Domain.Limits.Queries.GetLatest;
using Lab.Aml.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Repositories;

public sealed class LimitRepository(AppDbContext dbContext)
	: IAddLimitRepository,
		IGetLatestLimitsRepository,
		IGetLimitHistoryRepository
{
	public void Add(AddLimitCommand limit)
	{
		dbContext.Limits.Add(
			new Entities.Limit
			{
				CreationDate = DateTime.UtcNow,
				Amount = limit.Amount,
				Currency = limit.Currency,
				Count = limit.Count,
				Range = limit.Range,
			});
	}

	public async Task<Limit> GetLatestAsync(Currency currency, CancellationToken cancellationToken)
	{
		return await dbContext.Limits
			.Where(l => l.Currency == currency)
			.OrderByDescending(l => l.CreationDate)
			.Select(l => l!.ToDomainValue())
			.FirstAsync(cancellationToken);
	}

	public async Task<List<Limit>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await dbContext.Limits
			.Select(l => l.ToDomainValue())
			.ToListAsync(cancellationToken);
	}

	public async Task SaveChangesAsync(CancellationToken cancellationToken)
	{
		await dbContext.SaveChangesAsync(cancellationToken);
	}
}
