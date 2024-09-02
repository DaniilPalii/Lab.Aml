using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Add;

namespace Lab.Aml.WebApi.TransferObjects;

public sealed record AddingTransaction(
	decimal Amount,
	Currency Currency,
	TransactionType TransactionType,
	DateTime CreationDate,
	string Description,
	long CustomerId)
{
	public AddTransactionCommand ToCommand()
	{
		return new(
			Amount: Amount,
			Currency: Currency,
			TransactionType: TransactionType,
			CreationDate: CreationDate.ToUniversalTime(),
			Description: Description,
			CustomerId: CustomerId);
	}
}
