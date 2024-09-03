using Lab.Aml.Domain.Transactions;
using MediatR;

namespace Lab.Aml.Domain.Limits.Queries.GetLatest;

public sealed class GetLatestLimitsQueryHandler(IGetLatestLimitsRepository repository)
	: IRequestHandler<GetLatestLimitsQuery, Limit[]>
{
	public async Task<Limit[]> Handle(GetLatestLimitsQuery request, CancellationToken cancellationToken)
	{
		var currencies = Enum.GetValues<Currency>();
		var limits = new Limit[currencies.Length];

		for (var i = 0; i < currencies.Length; i++)
		{
			limits[i] = await repository.GetLatestAsync(currencies[i], cancellationToken);
		}

		return limits;
	}
}
