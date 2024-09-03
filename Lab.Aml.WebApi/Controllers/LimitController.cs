using Lab.Aml.Domain.Limits;
using Lab.Aml.Domain.Limits.Queries.GetHistory;
using Lab.Aml.Domain.Limits.Queries.GetLatest;
using Lab.Aml.WebApi.TransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Aml.WebApi.Controllers;

[ApiController]
[Route("limits")]
public sealed class LimitController(IMediator mediator) : ControllerBase
{
	[HttpPost]
	public Task Add(AddingLimit limit, CancellationToken cancellationToken)
	{
		return mediator.Send(
			limit.ToCommand(),
			cancellationToken);
	}

	[HttpGet]
	public Task<Limit[]> Get(CancellationToken cancellationToken)
	{
		return mediator.Send(
			new GetLatestLimitsQuery(),
			cancellationToken);
	}

	[HttpGet("history")]
	public Task<List<Limit>> GetHistory(CancellationToken cancellationToken)
	{
		return mediator.Send(
			new GetLimitHistoryQuery(),
			cancellationToken);
	}
}
