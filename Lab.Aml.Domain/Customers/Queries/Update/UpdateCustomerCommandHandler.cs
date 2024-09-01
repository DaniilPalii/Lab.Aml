using MediatR;

namespace Lab.Aml.Domain.Customers.Commands.Add;

public sealed class UpdateCustomerCommandHandler(IUpdateCustomerRepository repository)
	: IRequestHandler<UpdateCustomerCommand>
{
	public Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		repository.Update(request);

		return repository.SaveChangesAsync(cancellationToken);
	}
}
