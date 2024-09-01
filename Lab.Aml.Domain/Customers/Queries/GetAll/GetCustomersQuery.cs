using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.GetAll;

public sealed record GetCustomersQuery
	: IRequest<IEnumerable<Customer>>;
