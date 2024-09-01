using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.GetById;

public sealed record GetCustomerByIdQuery(long Id)
	: IRequest<Customer?>;
