namespace Lab.Aml.Domain.Customers;

public class Customer
{
	public required long Id { get; set; }

	public required string Name { get; set; }

	public required string Surname { get; set; }

	public required DateOnly Birthdate { get; set; }

	public required string Address { get; set; }
}
