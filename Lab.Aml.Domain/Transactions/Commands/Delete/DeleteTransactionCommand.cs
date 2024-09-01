using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Delete;

public sealed record DeleteTransactionCommand(long Id)
	: IRequest;
