using MediatR;

namespace Lab.Aml.Domain.Customers.Queries.GetAll;

public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
{ }
