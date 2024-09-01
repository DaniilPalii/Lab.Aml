using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lab.Aml.Domain.Transactions;

namespace Lab.Aml.DataPersistence.Entities;

public class Transaction
{
	[Key]
	public long? Id { get; set; }

	public decimal? Amount { get; set; }

	public Currency? Currency { get; set; }

	public string? Description { get; set; }

	[ForeignKey(nameof(Customer))]
	public long? CustomerId { get; set; }

	public Customer? Customer { get; set; }

	public Domain.Transactions.Transaction ToDomainValue()
	{
		return new(
			Id: Id!.Value,
			Amount: Amount!.Value,
			Currency: Currency!.Value,
			Description: Description!,
			CustomerId: CustomerId!.Value);
	}
}
