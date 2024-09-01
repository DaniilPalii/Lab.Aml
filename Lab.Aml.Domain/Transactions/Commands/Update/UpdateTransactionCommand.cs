﻿using MediatR;

namespace Lab.Aml.Domain.Transactions.Commands.Update;

public sealed record UpdateTransactionCommand(
	long Id,
	decimal Amount,
	Currency Currency,
	string Description,
	long CustomerId)
	: IRequest;
