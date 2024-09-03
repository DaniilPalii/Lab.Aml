namespace Lab.Aml.Domain.Transactions.Commands.MarkAsSuspicious;

public interface IMarkTransactionsAsSuspiciousRepository
{
	void MarkAsSuspicious(long id);

	Task SaveChangesAsync(CancellationToken cancellationToken);
}
