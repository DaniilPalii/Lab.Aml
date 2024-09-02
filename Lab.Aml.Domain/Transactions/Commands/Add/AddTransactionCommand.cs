using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Add;

public sealed record AddTransactionCommand(
	decimal Amount,
	Currency Currency,
	TransactionType TransactionType,
	DateTime CreationDate,
	string Description,
	long CustomerId)
	: IRequest;
