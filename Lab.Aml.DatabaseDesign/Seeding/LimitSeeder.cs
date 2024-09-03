using Lab.Aml.DataPersistence.Entities;
using Lab.Aml.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DatabaseDesign.Seeding;

internal static class LimitSeeder
{
	internal static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Limit>().HasData(
		[
			// Old limits

			new()
			{
				Id = 1,
				Currency = Currency.PLN,
				Amount = 11_000,
				Count = 11,
				Range = TimeSpan.FromMinutes(5),
				CreationDate = new DateTime(2000, 1, 1),
			},
			new()
			{
				Id = 2,
				Currency = Currency.EUR,
				Amount = 12_000,
				Count = 12,
				Range = TimeSpan.FromMinutes(5),
				CreationDate = new DateTime(2000, 1, 1),
			},
			new()
			{
				Id = 3,
				Currency = Currency.USD,
				Amount = 13_000,
				Count = 13,
				Range = TimeSpan.FromMinutes(5),
				CreationDate = new DateTime(2000, 1, 1),
			},

			// Present limits

			new()
			{
				Id = 4,
				Currency = Currency.PLN,
				Amount = 21_000,
				Count = 21,
				Range = TimeSpan.FromMinutes(5),
				CreationDate = new DateTime(2024, 1, 1),
			},
			new()
			{
				Id = 5,
				Currency = Currency.EUR,
				Amount = 22_000,
				Count = 22,
				Range = TimeSpan.FromMinutes(6),
				CreationDate = new DateTime(2024, 1, 1),
			},
			new()
			{
				Id = 6,
				Currency = Currency.USD,
				Amount = 23_000,
				Count = 23,
				Range = TimeSpan.FromMinutes(7),
				CreationDate = new DateTime(2024, 1, 1),
			},
		]);
	}
}
