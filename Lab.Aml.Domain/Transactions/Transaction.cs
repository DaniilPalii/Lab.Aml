namespace Lab.Aml.Domain.Transactions;

public sealed class Transaction
{
	public required long Id { get; set; }

	public required decimal Amount { get; set; }

	public required Currency Currency { get; set; }

	public required string Description { get; set; }

	public required long CustomerId { get; set; }
}
