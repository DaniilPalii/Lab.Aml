using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.GetAll;

public sealed record GetAllCustomersQuery
	: IRequest<IEnumerable<Customer>>;
