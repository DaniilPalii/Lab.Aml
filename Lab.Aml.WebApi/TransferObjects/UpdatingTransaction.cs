using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Update;

namespace Lab.Aml.WebApi.TransferObjects;

public sealed record UpdatingTransaction(
	decimal Amount,
	Currency Currency,
	TransactionType TransactionType,
	DateTime CreationDate,
	string Description,
	long CustomerId)
{
	public UpdateTransactionCommand ToCommand(long id)
	{
		return new(
			Id: id,
			Amount: Amount,
			Currency: Currency,
			TransactionType: TransactionType,
			CreationDate: CreationDate.ToUniversalTime(),
			Description: Description,
			CustomerId: CustomerId);
	}
}
