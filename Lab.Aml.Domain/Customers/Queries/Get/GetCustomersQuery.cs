using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.Get;

public sealed record GetCustomersQuery(
	string? Name = null,
	string? Surname = null)
	: IRequest<List<Customer>>;
