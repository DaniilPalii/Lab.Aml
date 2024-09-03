using MediatR;

namespace Lab.Aml.Domain.Limits.Commands.Add;

public sealed class AddLimitCommandHandler(IAddLimitRepository repository)
	: IRequestHandler<AddLimitCommand>
{
	public Task Handle(AddLimitCommand request, CancellationToken cancellationToken)
	{
		repository.Add(request);

		return repository.SaveChangesAsync(cancellationToken);
	}
}
