using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Update;

public sealed class UpdateTransactionCommandHandler(IUpdateTransactionRepository repository)
	: IRequestHandler<UpdateTransactionCommand>
{
	public async Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		await repository.UpdateAsync(request, cancellationToken);
		await repository.SaveChangesAsync(cancellationToken);
	}
}
