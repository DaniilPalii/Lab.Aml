using Lab.Aml.DataPersistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DatabaseDesign.Seeding;

internal static class CustomerSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Customer>().HasData(
		[
			new()
			{
				Id = 1,
				Name = "Anna",
				Surname = "Kowalska",
				Birthdate = new DateOnly(1990, 6, 15),
				Address = "ul. Kwiatowa 5, 00-001 Warszawa",
			},
			new()
			{
				Id = 2,
				Name = "Jan",
				Surname = "Nowak",
				Birthdate = new DateOnly(1985, 3, 22),
				Address = "ul. Słoneczna 12, 31-234 Kraków",
			},
			new()
			{
				Id = 3,
				Name = "Katarzyna",
				Surname = "Zielińska",
				Birthdate = new DateOnly(1995, 10, 11),
				Address = "ul. Ogrodowa 8, 40-600 Katowice",
			},
		]);
	}
}
