using MediatR;

namespace Lab.Aml.Domain.Transactions.Queries.GetAll;

public sealed class GetAllTransactionsQueryHandler(IGetAllTransactionsRepository repository)
	: IRequestHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>
{
	public Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
	{
		return repository.GetAllAsync(cancellationToken);
	}
}
