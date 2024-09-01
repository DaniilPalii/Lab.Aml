using Lab.Aml.Domain.Customers;
using Lab.Aml.Domain.Customers.Commands.Add;
using Lab.Aml.Domain.Customers.Queries.GetAll;
using Lab.Aml.Domain.Customers.Queries.GetById;
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

	[HttpGet("{id:long}")]
	[ProducesResponseType<Customer>(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<Customer>> GetById(long id, CancellationToken cancellationToken)
	{
		var customer = await mediator.Send(new GetCustomerByIdQuery(id), cancellationToken);

		return customer is not null
			? customer
			: NotFound();
	}
}
