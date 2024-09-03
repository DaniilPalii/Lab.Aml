using MediatR;

namespace Lab.Aml.Domain.Customers.Commands.Delete;

public sealed class DeleteCustomerCommandHandler(IDeleteCustomerRepository repository)
	: IRequestHandler<DeleteCustomerCommand>
{
	public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
	{
		await repository.DeleteAsync(request.Id, cancellationToken);
		await repository.SaveChangesAsync(cancellationToken);
	}
}
