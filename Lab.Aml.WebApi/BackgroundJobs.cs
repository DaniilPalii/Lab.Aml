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

		StartRecurringTransactionVerification(application);
	}

	private static void StartRecurringTransactionVerification(WebApplication application)
	{
		var verificationMinuteInterval = int.Parse(application.Configuration["VerificationMinuteInterval"]!);

		RecurringJob.AddOrUpdate<IMediator>(
			recurringJobId: "VerifyTransactions",
			mediator => mediator.Send(new VerifyTransactionsCommand(), CancellationToken.None),
			MinuteIntervalCronExpression(verificationMinuteInterval));
	}

	private static string MinuteIntervalCronExpression(int minutes)
	{
		return $"*/{minutes} * * * *";
	}
}
