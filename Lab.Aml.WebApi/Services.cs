﻿using Lab.Aml.DataPersistence.Repositories;
using Lab.Aml.Domain.Customers.Commands.Add;
using Lab.Aml.Domain.Customers.Commands.Delete;
using Lab.Aml.Domain.Customers.Commands.Update;
using Lab.Aml.Domain.Customers.Queries.Get;
using Lab.Aml.Domain.Customers.Queries.GetById;
using Lab.Aml.Domain.Limits.Commands.Add;
using Lab.Aml.Domain.Limits.Queries.GetHistory;
using Lab.Aml.Domain.Limits.Queries.GetLatest;
using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Add;
using Lab.Aml.Domain.Transactions.Commands.Delete;
using Lab.Aml.Domain.Transactions.Commands.MarkAsSuspicious;
using Lab.Aml.Domain.Transactions.Commands.Update;
using Lab.Aml.Domain.Transactions.Commands.Verify;
using Lab.Aml.Domain.Transactions.Queries.Get;
using Lab.Aml.Domain.Transactions.Queries.GetById;

namespace Lab.Aml.WebApi;

internal static class Services
{
	public static void AddTo(WebApplicationBuilder builder)
	{
		builder.Services.AddMediatR(
			configuration => configuration.RegisterServicesFromAssemblyContaining<Currency>());

		builder.Services.AddScoped<IAddCustomerRepository, CustomerRepository>();
		builder.Services.AddScoped<IDeleteCustomerRepository, CustomerRepository>();
		builder.Services.AddScoped<IGetCustomerByIdRepository, CustomerRepository>();
		builder.Services.AddScoped<IGetCustomersRepository, CustomerRepository>();
		builder.Services.AddScoped<IUpdateCustomerRepository, CustomerRepository>();

		builder.Services.AddScoped<IAddTransactionRepository, TransactionRepository>();
		builder.Services.AddScoped<IDeleteTransactionRepository, TransactionRepository>();
		builder.Services.AddScoped<IGetTransactionByIdRepository, TransactionRepository>();
		builder.Services.AddScoped<IGetTransactionsRepository, TransactionRepository>();
		builder.Services.AddScoped<IMarkTransactionsAsSuspiciousRepository, TransactionRepository>();
		builder.Services.AddScoped<IUpdateTransactionRepository, TransactionRepository>();
		builder.Services.AddScoped<IVerifyTransactionsRepository, TransactionRepository>();

		builder.Services.AddScoped<IAddLimitRepository, LimitRepository>();
		builder.Services.AddScoped<IGetLatestLimitsRepository, LimitRepository>();
		builder.Services.AddScoped<IGetLimitHistoryRepository, LimitRepository>();
	}
}
