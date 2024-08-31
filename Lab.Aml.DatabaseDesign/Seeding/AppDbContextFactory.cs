using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Lab.Aml.DataPersistence.Context;

namespace Lab.Aml.DatabaseDesign.Seeding;

internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	public AppDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

		optionsBuilder.UseSqlServer(
			builder => builder.MigrationsAssembly("Lab.Aml.DatabaseDesign"));

		optionsBuilder.EnableSensitiveDataLogging();

		return new AppDbContext(optionsBuilder.Options);
	}
}
