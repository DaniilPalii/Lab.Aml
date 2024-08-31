using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Context;

public partial class AppDbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}
}
