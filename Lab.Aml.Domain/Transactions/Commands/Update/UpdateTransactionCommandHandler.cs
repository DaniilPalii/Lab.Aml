using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Update;

public sealed class UpdateTransactionCommandHandler(IUpdateTransactionRepository repository)
	: IRequestHandler<UpdateTransactionCommand>
{
	public Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		repository.Update(request);

		return repository.SaveChangesAsync(cancellationToken);
	}
}
