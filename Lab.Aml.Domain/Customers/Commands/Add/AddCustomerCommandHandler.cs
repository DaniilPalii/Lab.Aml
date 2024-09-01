using MediatR;

namespace Lab.Aml.Domain.Customers.Commands.Add;

public class AddCustomerCommandHandler(IAddCustomerRepository repository)
	: IRequestHandler<AddCustomerCommand>
{
	public Task Handle(AddCustomerCommand request, CancellationToken cancellationToken)
	{
		repository.Add(request);

		return repository.SaveChangesAsync(cancellationToken);
	}
}
