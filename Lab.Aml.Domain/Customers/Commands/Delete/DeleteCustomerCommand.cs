using MediatR;

namespace Lab.Aml.Domain.Customers.Commands.Delete;

public sealed record DeleteCustomerCommand(long Id)
	: IRequest;
