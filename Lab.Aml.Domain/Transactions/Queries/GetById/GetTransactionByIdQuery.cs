using MediatR;

namespace Lab.Aml.Domain.Transactions.Queries.GetById;

public sealed record GetTransactionByIdQuery(long Id)
	: IRequest<Transaction?>;
