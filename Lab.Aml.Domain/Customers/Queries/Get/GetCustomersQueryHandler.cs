using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.Get;

public sealed class GetCustomersQueryHandler(IGetCustomersRepository repository)
	: IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
{
	public Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
	{
		return repository.GetAllAsync(cancellationToken);
	}
}
