using Lab.Aml.DataPersistence.Repositories;
using Lab.Aml.Domain.Customers.Commands.Add;
using Lab.Aml.Domain.Customers.Queries.GetAll;
using Lab.Aml.Domain.Customers.Queries.GetById;
using Lab.Aml.Domain.Transactions;

namespace Lab.Aml.WebApi;

internal static class Services
{
	public static void AddTo(WebApplicationBuilder builder)
	{
		builder.Services.AddMediatR(
			configuration => configuration.RegisterServicesFromAssemblyContaining<Currency>());

		builder.Services.AddScoped<IAddCustomerRepository, CustomerRepository>();
		builder.Services.AddScoped<IGetAllCustomersRepository, CustomerRepository>();
		builder.Services.AddScoped<IGetCustomerByIdRepository, CustomerRepository>();
	}
}
