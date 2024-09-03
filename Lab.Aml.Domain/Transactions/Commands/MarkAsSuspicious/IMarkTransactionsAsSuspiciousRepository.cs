namespace Lab.Aml.Domain.Transactions.Commands.MarkAsSuspicious;

public interface IMarkTransactionsAsSuspiciousRepository
{
	Task MarkAsSuspiciousAsync(long id, CancellationToken cancellationToken);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
