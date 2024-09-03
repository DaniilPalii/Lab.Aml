using Lab.Aml.DataPersistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab.Aml.DataPersistence.Context;

public partial class AppDbContext(DbContextOptions<AppDbContext> options)
	: DbContext(options)
{
	public virtual DbSet<Customer> Customers { get; set; }

	public virtual DbSet<Transaction> Transactions { get; set; }

	public virtual DbSet<Limit> Limits { get; set; }
}
