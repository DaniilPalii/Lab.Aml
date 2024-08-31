using Lab.Aml.DataPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.WebApi;

internal static class Database
{
	public static void AddTo(WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<AppDbContext>(options =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"));

#if DEBUG
			options.EnableSensitiveDataLogging();
			options.EnableDetailedErrors();
#endif
		});
	}
}
