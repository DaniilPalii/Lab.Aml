using MediatR;

namespace Lab.Aml.Domain.Transactions.Queries.GetById;

public sealed class GetTransactionByIdQueryHandler(IGetTransactionByIdRepository repository)
	: IRequestHandler<GetTransactionByIdQuery, Transaction?>
{
	public Task<Transaction?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
	{
		return repository.GetByIdAsync(request.Id, cancellationToken);
	}
}
