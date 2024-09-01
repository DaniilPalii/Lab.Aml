using MediatR;

namespace Lab.Aml.Domain.Transactions.Queries.GetAll;

public sealed class GetTransactionsQueryHandler(IGetTransactionsRepository repository)
	: IRequestHandler<GetTransactionsQuery, IEnumerable<Transaction>>
{
	public Task<IEnumerable<Transaction>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
	{
		return repository.GetAllAsync(cancellationToken);
	}
}
