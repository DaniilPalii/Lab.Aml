using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Add;

namespace Lab.Aml.WebApi.TransferObjects;

public sealed record AddingTransaction(
	decimal Amount,
	Currency Currency,
	string Description,
	long CustomerId)
{
	public AddTransactionCommand ToCommand()
	{
		return new(
			Amount: Amount,
			Currency: Currency,
			Description: Description,
			CustomerId: CustomerId);
	}
}
