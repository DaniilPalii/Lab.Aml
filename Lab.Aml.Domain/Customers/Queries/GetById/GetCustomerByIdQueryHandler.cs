using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.GetById;

public sealed class GetCustomerByIdQueryHandler(IGetCustomerByIdRepository repository)
	: IRequestHandler<GetCustomerByIdQuery, Customer?>
{
	public Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
	{
		return repository.GetByIdAsync(request.Id, cancellationToken);
	}
}
