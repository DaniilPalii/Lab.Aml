using Hangfire;

namespace Lab.Aml.WebApi;

internal static class BackgroundJobs
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddHangfire(
			configuration => configuration.UseSqlServerStorage(
				builder.Configuration.GetConnectionString(Database.ConnectionStringName)));

		builder.Services.AddHangfireServer();
	}

	public static void UseIn(WebApplication application)
	{
		application.UseHangfireDashboard();

		RecurringJob.AddOrUpdate(
			recurringJobId: "VerifyTransactions",
			() => Console.WriteLine("Recurring!"),
			MinuteIntervalCronExpression(5));
	}

	private static string MinuteIntervalCronExpression(int minutes)
	{
		return $"*/{minutes} * * * *";
	}
}
