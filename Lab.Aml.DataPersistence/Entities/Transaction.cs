using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lab.Aml.Domain.Transactions;

namespace Lab.Aml.DataPersistence.Entities;

public class Transaction
{
	[Key]
	public long? Id { get; set; }

	[Required]
	public decimal? Amount { get; set; }

	[Required]
	public Currency? Currency { get; set; }

	[Required]
	public TransactionType? TransactionType { get; set; }

	[Required]
	public DateTime? CreationDate { get; set; }

	[Required]
	public string? Description { get; set; }

	public bool? IsSuspicious { get; set; }

	[ForeignKey(nameof(Customer))]
	public long? CustomerId { get; set; }

	public Customer? Customer { get; set; }

	public Domain.Transactions.Transaction ToDomainValue()
	{
		return new(
			Id: Id!.Value,
			Amount: Amount!.Value,
			Currency: Currency!.Value,
			CreationDate: CreationDate!.Value,
			TransactionType: TransactionType!.Value,
			Description: Description!,
			CustomerId: CustomerId!.Value);
	}
}
