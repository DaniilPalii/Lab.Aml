using MediatR;

namespace Lab.Aml.Domain.Limits.Queries.GetHistory;

public sealed record GetLimitHistoryQuery : IRequest<List<Limit>>;
