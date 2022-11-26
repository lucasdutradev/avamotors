using Avamotors.Domain.Entities;
using Avamotors.Domain.Infra.Mapping;
using Avamotors.Domain.Shared.VOs;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Avamotors.Domain.Infra.Contexts;

public class DataContext : DbContext
{
	public DbSet<Car> Car { get; set; }
	public DbSet<Client> Client { get; set; }
	public DbSet<Seller> Seller { get; set; }
	public DbSet<Availability> Availability { get; set; }
	public DataContext(DbContextOptions options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CarMapping());
		modelBuilder.ApplyConfiguration(new SellerMapping());
		modelBuilder.ApplyConfiguration(new AvailabilityMapping());
		modelBuilder.ApplyConfiguration(new ClientMapping());
	}
}