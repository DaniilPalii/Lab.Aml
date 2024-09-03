﻿using Hangfire;
using Lab.Aml.Domain.Transactions.Commands.Verify;
using MediatR;

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

		RecurringJob.AddOrUpdate<IMediator>(
			recurringJobId: "VerifyTransactions",
			mediator => mediator.Send(new VerifyTransactionsCommand(), CancellationToken.None),
			MinuteIntervalCronExpression(2));
	}

	private static string MinuteIntervalCronExpression(int minutes)
	{
		return $"*/{minutes} * * * *";
	}
}
