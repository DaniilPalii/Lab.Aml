namespace Lab.Aml.Domain.Limits.Commands.Add;

public interface IAddLimitRepository
{
	void Add(AddLimitCommand customer);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
