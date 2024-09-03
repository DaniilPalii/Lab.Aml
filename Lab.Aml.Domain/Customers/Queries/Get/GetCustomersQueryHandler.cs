using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.Get;

public sealed class GetCustomersQueryHandler(IGetCustomersRepository repository)
	: IRequestHandler<GetCustomersQuery, List<Customer>>
{
	public Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
	{
		return repository.GetAsync(request, cancellationToken);
	}
}
