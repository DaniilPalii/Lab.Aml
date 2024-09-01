namespace Lab.Aml.Domain.Transactions;

public sealed record Transaction(
	long Id,
	decimal Amount,
	Currency Currency,
	string Description,
	long CustomerId);
