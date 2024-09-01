using MediatR;

namespace Lab.Aml.Domain.Customers.Commands.Add;

public sealed record UpdateCustomerCommand(
	long Id,
	string Name,
	string Surname,
	DateOnly Birthdate,
	string Address)
	: IRequest;
