using Lab.Aml.Domain.Customers.Commands.Add;

namespace Lab.Aml.WebApi.TransferObjects;

public sealed record AddingCustomer(
	string Name,
	string Surname,
	DateOnly Birthdate,
	string Address)
{
	public AddCustomerCommand ToCommand()
	{
		return new(
			Name,
			Surname,
			Birthdate,
			Address);
	}
}
