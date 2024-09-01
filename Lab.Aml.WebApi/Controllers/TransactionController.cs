using Lab.Aml.Domain.Customers;
using Lab.Aml.Domain.Customers.Commands.Delete;
using Lab.Aml.Domain.Customers.Queries.GetById;
using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Delete;
using Lab.Aml.Domain.Transactions.Queries.GetAll;
using Lab.Aml.Domain.Transactions.Queries.GetById;
using Lab.Aml.WebApi.TransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Aml.WebApi.Controllers;

[ApiController]
[Route("transactions")]
public sealed class TransactionController(IMediator mediator) : ControllerBase
{
	[HttpPost]
	public Task Add(AddingTransaction transaction, CancellationToken cancellationToken)
	{
		return mediator.Send(
			transaction.ToCommand(),
			cancellationToken);
	}

	[HttpGet]
	public Task<IEnumerable<Transaction>> Get(CancellationToken cancellationToken)
	{
		return mediator.Send(
			new GetAllTransactionsQuery(),
			cancellationToken);
	}

	[HttpGet("{id:long}")]
	[ProducesResponseType<Transaction>(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<Transaction>> GetById(long id, CancellationToken cancellationToken)
	{
		var transaction = await mediator.Send(
			new GetTransactionByIdQuery(id),
			cancellationToken);

		return transaction is not null
			? transaction
			: NotFound();
	}

	[HttpPut("{id:long}")]
	public Task Update(long id, UpdatingTransaction transaction, CancellationToken cancellationToken)
	{
		return mediator.Send(
			transaction.ToCommand(id),
			cancellationToken);
	}

	[HttpDelete("{id:long}")]
	public Task Delete(long id, CancellationToken cancellationToken)
	{
		return mediator.Send(
			new DeleteTransactionCommand(id),
			cancellationToken);
	}
}
