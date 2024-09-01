namespace Lab.Aml.Domain.Customers;

public sealed record Customer(
	long Id,
	string Name,
	string Surname,
	DateOnly Birthdate,
	string Address);
