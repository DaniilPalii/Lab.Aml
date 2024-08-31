using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Aml.DataPersistence.Entities;

public class Customer
{
	[Key]
	public required long Id { get; set; }

	public required string Name { get; set; }

	public required string Surname { get; set; }

	public required DateOnly Birthdate { get; set; }

	public required string Address { get; set; }

	public required List<Transaction> Transactions { get; set; }
}
