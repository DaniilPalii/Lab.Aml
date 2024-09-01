using MediatR;

namespace Lab.Aml.Domain.Transactions.Queries.GetByCustomerId;

public class GetTransactionByCustomerIdQuery(long CustomerId)
	: IRequest<Transaction?>;
