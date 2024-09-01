using Lab.Aml.DataPersistence.Repositories;
using Lab.Aml.Domain.Customers.Commands.Add;
using Lab.Aml.Domain.Customers.Commands.Delete;
using Lab.Aml.Domain.Customers.Commands.Update;
using Lab.Aml.Domain.Customers.Queries.GetAll;
using Lab.Aml.Domain.Customers.Queries.GetById;
using Lab.Aml.Domain.Transactions;
using Lab.Aml.Domain.Transactions.Commands.Add;
using Lab.Aml.Domain.Transactions.Commands.Delete;
using Lab.Aml.Domain.Transactions.Commands.Update;
using Lab.Aml.Domain.Transactions.Queries.GetAll;
using Lab.Aml.Domain.Transactions.Queries.GetById;

namespace Lab.Aml.WebApi;

internal static class Services
{
	public static void AddTo(WebApplicationBuilder builder)
	{
		builder.Services.AddMediatR(
			configuration => configuration.RegisterServicesFromAssemblyContaining<Currency>());

		builder.Services.AddScoped<IAddCustomerRepository, CustomerRepository>();
		builder.Services.AddScoped<IGetCustomersRepository, CustomerRepository>();
		builder.Services.AddScoped<IGetCustomerByIdRepository, CustomerRepository>();
		builder.Services.AddScoped<IUpdateCustomerRepository, CustomerRepository>();
		builder.Services.AddScoped<IDeleteCustomerRepository, CustomerRepository>();

		builder.Services.AddScoped<IAddTransactionRepository, TransactionRepository>();
		builder.Services.AddScoped<IGetTransactionsRepository, TransactionRepository>();
		builder.Services.AddScoped<IGetTransactionByIdRepository, TransactionRepository>();
		builder.Services.AddScoped<IUpdateTransactionRepository, TransactionRepository>();
		builder.Services.AddScoped<IDeleteTransactionRepository, TransactionRepository>();
	}
}
