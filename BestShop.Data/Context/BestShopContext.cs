using BestShop.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace BestShop.Data.Context;
public class BestShopContext(DbContextOptions<BestShopContext> options) : DbContext(options)
{
	#region Users
	public DbSet<User> Users { get; set; }
	#endregion Users


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
		base.OnModelCreating(modelBuilder);
	}
}
