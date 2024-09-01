using MediatR;

namespace Lab.Aml.Domain.Customers.Commands.Add;

public class AddCustomerCommand : IRequest
{
	public required string Name { get; set; }

	public required string Surname { get; set; }

	public required DateOnly Birthdate { get; set; }

	public required string Address { get; set; }
}
