using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Delete;

public sealed class DeleteTransactionCommandHandler(IDeleteTransactionRepository repository)
	: IRequestHandler<DeleteTransactionCommand>
{
	public async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
	{
		await repository.DeleteAsync(request.Id, cancellationToken);
		await repository.SaveChangesAsync(cancellationToken);
	}
}
