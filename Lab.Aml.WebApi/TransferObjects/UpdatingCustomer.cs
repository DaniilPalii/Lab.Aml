using Lab.Aml.Domain.Customers.Commands.Update;

namespace Lab.Aml.WebApi.TransferObjects;

public sealed record UpdatingCustomer(
	string Name,
	string Surname,
	DateOnly Birthdate,
	string Address)
{
	public UpdateCustomerCommand ToCommand(long id)
	{
		return new(
			id,
			Name,
			Surname,
			Birthdate,
			Address);
	}
}
