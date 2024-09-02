using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Update;

public sealed record UpdateTransactionCommand(
	long Id,
	decimal Amount,
	Currency Currency,
	TransactionType TransactionType,
	DateTime CreationDate,
	string Description,
	long CustomerId)
	: IRequest;
