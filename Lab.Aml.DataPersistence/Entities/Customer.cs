using System.ComponentModel.DataAnnotations;

namespace Lab.Aml.DataPersistence.Entities;

public class Customer
{
	[Key]
	public long? Id { get; set; }

	[Required]
	public string? Name { get; set; }

	[Required]
	public string? Surname { get; set; }

	[Required]
	public DateOnly? Birthdate { get; set; }

	[Required]
	public string? Address { get; set; }

	public List<Transaction>? Transactions { get; set; }

	public Domain.Customers.Customer ToDomainValue()
	{
		return new(
			Id: Id!.Value,
			Name: Name!,
			Surname: Surname!,
			Birthdate: Birthdate!.Value,
			Address: Address!);
	}
}
