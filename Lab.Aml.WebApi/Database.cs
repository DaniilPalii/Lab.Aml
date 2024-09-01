using Lab.Aml.DataPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.WebApi;

internal static class Database
{
	public const string ConnectionStringName = "AppDb";

	public static void AddTo(WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<AppDbContext>(options =>
		{
			options.UseSqlServer(
				builder.Configuration.GetConnectionString(ConnectionStringName));

#if DEBUG
			options.EnableSensitiveDataLogging();
			options.EnableDetailedErrors();
#endif
		});
	}
}
