using Lab.Aml.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DatabaseDesign.Seeding;

internal static class TransactionSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<DataPersistence.Entities.Transaction>().HasData(
		[
			new()
			{
				Id = 1,
				Amount = 150.00m,
				Currency = Currency.USD,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 1, 1, 14, 30, 0),
				Description = "Initial deposit",
				CustomerId = 1,
			},
			new()
			{
				Id = 2,
				Amount = 75.50m,
				Currency = Currency.USD,
				TransactionType = TransactionType.Withdrawal,
				CreationDate = new DateTime(2023, 1, 2, 9, 15, 0),
				Description = "ATM withdrawal",
				CustomerId = 1,
			},
			new()
			{
				Id = 3,
				Amount = 300.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Withdrawal,
				CreationDate = new DateTime(2023, 1, 3, 11, 45, 0),
				Description = "Online transfer",
				CustomerId = 2,
			},
			new()
			{
				Id = 4,
				Amount = 1000.00m,
				Currency = Currency.PLN,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 1, 4, 10, 0, 0),
				Description = "Salary deposit",
				CustomerId = 3,
			},
			new()
			{
				Id = 5,
				Amount = 50.00m,
				Currency = Currency.USD,
				TransactionType = TransactionType.Withdrawal,
				CreationDate = new DateTime(2023, 1, 5, 16, 20, 0),
				Description = "Grocery payment",
				CustomerId = 1,
			},
			new()
			{
				Id = 6,
				Amount = 120.00m,
				Currency = Currency.USD,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 1, 6, 13, 10, 0),
				Description = "Gift deposit",
				CustomerId = 2,
			},
			new()
			{
				Id = 7,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 2, 15, 17, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 8,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 3, 15, 17, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 9,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 17, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 10,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 18, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 11,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 19, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 12,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 20, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 13,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 21, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 14,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 22, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 15,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 30, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 16,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 31, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 17,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 32, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 18,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 33, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 19,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 34, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 20,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 35, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 21,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 36, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 22,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 37, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 23,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 38, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 24,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 39, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 25,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 40, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 26,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 41, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 27,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 42, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 28,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 43, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 29,
				Amount = 450.00m,
				Currency = Currency.USD,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 44, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 30,
				Amount = 45.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2023, 4, 15, 23, 45, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 31,
				Amount = 100.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2024, 1, 1, 1, 1, 0),
				Description = "Online shopping",
				CustomerId = 3,
			},
			new()
			{
				Id = 32,
				Amount = 100_000.00m,
				Currency = Currency.EUR,
				TransactionType = TransactionType.Deposit,
				CreationDate = new DateTime(2024, 2, 1, 1, 1, 0),
				Description = "Online shopping",
				CustomerId = 1,
			},
		]);
	}
}
