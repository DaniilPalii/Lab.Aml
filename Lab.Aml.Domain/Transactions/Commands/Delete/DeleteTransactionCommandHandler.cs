using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Delete;

public sealed class DeleteTransactionCommandHandler(IDeleteTransactionRepository repository)
	: IRequestHandler<DeleteTransactionCommand>
{
	public Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
	{
		repository.Delete(request.Id);

		return repository.SaveChangesAsync(cancellationToken);
	}
}
