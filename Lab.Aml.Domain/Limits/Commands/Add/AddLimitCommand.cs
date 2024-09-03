using Lab.Aml.Domain.Transactions;
using MediatR;

namespace Lab.Aml.Domain.Limits.Commands.Add;

public sealed record AddLimitCommand(
	Currency Currency,
	decimal Amount,
	int Count,
	TimeSpan Range)
	: IRequest;
