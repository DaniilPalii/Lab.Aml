using MediatR;

namespace Lab.Aml.Domain.Customers.Commands.Update;

public sealed class UpdateCustomerCommandHandler(IUpdateCustomerRepository repository)
	: IRequestHandler<UpdateCustomerCommand>
{
	public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		await repository.UpdateAsync(request, cancellationToken);
		await repository.SaveChangesAsync(cancellationToken);
	}
}
