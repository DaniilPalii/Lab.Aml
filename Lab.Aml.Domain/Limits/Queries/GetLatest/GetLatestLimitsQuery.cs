using MediatR;

namespace Lab.Aml.Domain.Limits.Queries.GetLatest;

public sealed record GetLatestLimitsQuery : IRequest<Limit[]>;
