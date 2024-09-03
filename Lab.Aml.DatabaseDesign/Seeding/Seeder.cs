using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DatabaseDesign.Seeding;

internal static class Seeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		LimitSeeder.Seed(modelBuilder);
	}
}
