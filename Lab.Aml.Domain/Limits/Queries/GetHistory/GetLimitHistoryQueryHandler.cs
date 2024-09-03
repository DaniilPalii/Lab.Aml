using MediatR;

namespace Lab.Aml.Domain.Limits.Queries.GetHistory;

public sealed class GetLimitHistoryQueryHandler(IGetLimitHistoryRepository repository)
	: IRequestHandler<GetLimitHistoryQuery, List<Limit>>
{
	public Task<List<Limit>> Handle(GetLimitHistoryQuery request, CancellationToken cancellationToken)
	{
		return repository.GetAllAsync(cancellationToken);
	}
}
