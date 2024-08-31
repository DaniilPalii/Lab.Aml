using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Aml.DataPersistence.Entities;

public class Transaction
{
	[Key]
	public required long Id { get; set; }

	public required decimal Amount { get; set; }

	public required Currency Currency { get; set; }

	public required string Description { get; set; }

	[ForeignKey(nameof(Customer))]
	public required long CustomerId { get; set; }

	public required long Customer { get; set; }
}
