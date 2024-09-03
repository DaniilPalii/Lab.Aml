using Lab.Aml.Domain.Transactions;

namespace Lab.Aml.Domain.Limits.Queries.GetLatest;

public interface IGetLatestLimitsRepository
{
	Task<Limit> GetLatestAsync(Currency currency, CancellationToken cancellationToken);
}
