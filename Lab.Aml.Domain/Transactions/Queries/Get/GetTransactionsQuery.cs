using MediatR;

namespace Lab.Aml.Domain.Transactions.Queries.Get;

public sealed record GetTransactionsQuery(long? CustomerId = null)
	: IRequest<IEnumerable<Transaction>>;
