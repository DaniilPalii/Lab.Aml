using Lab.Aml.Domain.Customers;
using Lab.Aml.Domain.Customers.Commands.Delete;
using Lab.Aml.Domain.Customers.Queries.Get;
using Lab.Aml.Domain.Customers.Queries.GetById;
using Lab.Aml.WebApi.TransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Aml.WebApi.Controllers;

[ApiController]
[Route("customers")]
public sealed class CustomerController(IMediator mediator) : ControllerBase
{
	[HttpPost]
	public Task Add(AddingCustomer customer, CancellationToken cancellationToken)
	{
		return mediator.Send(
			customer.ToCommand(),
			cancellationToken);
	}

	[HttpGet]
	public Task<List<Customer>> Get(CancellationToken cancellationToken)
	{
		return mediator.Send(
			new GetCustomersQuery(),
			cancellationToken);
	}

	[HttpGet("{id:long}")]
	[ProducesResponseType<Customer>(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<Customer>> GetById(long id, CancellationToken cancellationToken)
	{
		var customer = await mediator.Send(
			new GetCustomerByIdQuery(id),
			cancellationToken);

		return customer is not null
			? customer
			: NotFound();
	}

	[HttpPut("{id:long}")]
	public Task Update(long id, UpdatingCustomer customer, CancellationToken cancellationToken)
	{
		return mediator.Send(
			customer.ToCommand(id),
			cancellationToken);
	}

	[HttpDelete("{id:long}")]
	public Task Delete(long id, CancellationToken cancellationToken)
	{
		return mediator.Send(
			new DeleteCustomerCommand(id),
			cancellationToken);
	}
}
