namespace Lab.Aml.Domain.Transactions;

public sealed record Transaction(
	long Id,
	decimal Amount,
	Currency Currency,
	TransactionType TransactionType,
	DateTime CreationDate,
	string Description,
	long CustomerId);
