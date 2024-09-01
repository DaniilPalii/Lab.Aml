using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Add;

public sealed class AddTransactionCommandHandler(IAddTransactionRepository repository)
	: IRequestHandler<AddTransactionCommand>
{
	public Task Handle(AddTransactionCommand request, CancellationToken cancellationToken)
	{
		repository.Add(request);

		return repository.SaveChangesAsync(cancellationToken);
	}
}
