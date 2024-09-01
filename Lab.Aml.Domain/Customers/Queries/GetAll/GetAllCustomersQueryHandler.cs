using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.GetAll;

public class GetAllCustomersQueryHandler(IGetAllCustomersRepository repository)
	: IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
{
	public Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
	{
		return repository.GetAllAsync(cancellationToken);
	}
}
