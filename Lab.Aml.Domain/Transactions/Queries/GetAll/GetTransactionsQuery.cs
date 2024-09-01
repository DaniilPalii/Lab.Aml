using MediatR;

namespace Lab.Aml.Domain.Transactions.Queries.GetAll;

public sealed record GetTransactionsQuery
	: IRequest<IEnumerable<Transaction>>;
