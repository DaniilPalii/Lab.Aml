using Lab.Aml.Domain.Transactions;

namespace Lab.Aml.Domain.Limits;

public sealed record Limit(
	long Id,
	Currency Currency,
	DateTime CreationDate,
	decimal Amount,
	int Count,
	TimeSpan Range);
