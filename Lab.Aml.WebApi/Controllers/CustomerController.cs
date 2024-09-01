using Lab.Aml.Domain.Customers;
using Lab.Aml.Domain.Customers.Commands.Add;
using Lab.Aml.Domain.Customers.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Aml.WebApi.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController(IMediator mediator) : ControllerBase
{
	[HttpPost]
	public Task Add(AddCustomerCommand customer, CancellationToken cancellationToken)
	{
		return mediator.Send(customer, cancellationToken);
	}

	[HttpGet]
	public Task<IEnumerable<Customer>> Get(CancellationToken cancellationToken)
	{
		return mediator.Send(new GetAllCustomersQuery(), cancellationToken);
	}
}
