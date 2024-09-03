namespace Lab.Aml.Domain.Limits.Queries.GetHistory;

public interface IGetLimitHistoryRepository
{
	Task<List<Limit>> GetAllAsync(CancellationToken cancellationToken);
}
