using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Add;

public sealed record AddTransactionCommand(
	decimal Amount,
	Currency Currency,
	string Description,
	long CustomerId)
	: IRequest;
