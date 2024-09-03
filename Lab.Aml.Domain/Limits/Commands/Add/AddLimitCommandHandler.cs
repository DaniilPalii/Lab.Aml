using MediatR;

namespace Lab.Aml.Domain.Limits.Commands.Add;

public sealed class AddLimitCommandHandler(IAddLimitRepository repository)
	: IRequestHandler<UpdateLimitCommand>
{
	public Task Handle(UpdateLimitCommand request, CancellationToken cancellationToken)
	{
		repository.Add(request);

		return repository.SaveChangesAsync(cancellationToken);
	}
}
