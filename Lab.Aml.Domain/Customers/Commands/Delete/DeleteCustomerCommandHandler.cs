using MediatR;

namespace Lab.Aml.Domain.Customers.Commands.Delete;

public sealed class DeleteCustomerCommandHandler(IDeleteCustomerRepository repository)
	: IRequestHandler<DeleteCustomerCommand>
{
	public Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
	{
		repository.Delete(request.Id);

		return repository.SaveChangesAsync(cancellationToken);
	}
}
