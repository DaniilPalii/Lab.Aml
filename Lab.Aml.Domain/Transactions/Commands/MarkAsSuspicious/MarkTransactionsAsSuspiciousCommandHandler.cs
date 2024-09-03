using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.MarkAsSuspicious;

public sealed class MarkTransactionsAsSuspiciousCommandHandler(IMarkTransactionsAsSuspiciousRepository repository)
	: IRequestHandler<MarkTransactionsAsSuspiciousCommand>
{
	public async Task Handle(MarkTransactionsAsSuspiciousCommand request, CancellationToken cancellationToken)
	{
		repository.MarkAsSuspicious(request.Id);

		await repository.SaveChangesAsync(cancellationToken);
	}
}
