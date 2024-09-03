using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.Get;

public sealed record GetCustomersQuery
	: IRequest<List<Customer>>;
