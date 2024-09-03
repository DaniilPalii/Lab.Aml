namespace Lab.Aml.Domain.Limits.Commands.Add;

public interface IAddLimitRepository
{
	void Add(UpdateLimitCommand customer);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
