using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Context;

public partial class AppDbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options, Action<ModelBuilder> seedModel)
		: this(options)
	{
		this.seedModel = seedModel;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		seedModel?.Invoke(modelBuilder);
	}

	private readonly Action<ModelBuilder>? seedModel;
}
