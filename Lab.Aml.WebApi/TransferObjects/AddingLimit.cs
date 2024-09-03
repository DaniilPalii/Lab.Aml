using Lab.Aml.Domain.Limits.Commands.Add;
using Lab.Aml.Domain.Transactions;

namespace Lab.Aml.WebApi.TransferObjects;

public sealed record AddingLimit(
	Currency Currency,
	decimal Amount,
	int Count,
	int RangeMinutes)
{
	public UpdateLimitCommand ToCommand()
	{
		return new(
			Currency,
			Amount,
			Count,
			Range: TimeSpan.FromMinutes(RangeMinutes));
	}
}
