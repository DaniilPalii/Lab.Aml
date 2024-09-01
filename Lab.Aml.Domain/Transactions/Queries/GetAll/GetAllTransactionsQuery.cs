using MediatR;

namespace Lab.Aml.Domain.Transactions.Queries.GetAll;

public sealed record GetAllTransactionsQuery
	: IRequest<IEnumerable<Transaction>>;
