using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Data.Mappings;
using Smartwyre.DeveloperTest.Entities;
using EF = Microsoft.EntityFrameworkCore;

namespace Smartwyre.DeveloperTest.Data.DbContext
{
	public class SmartwyreDbContext : EF.DbContext
	{
		public SmartwyreDbContext(DbContextOptions<SmartwyreDbContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Rebate> Rebates { get; set; }
		public DbSet<RebateCalculation> RebateCalculations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductDbMapping());
			modelBuilder.ApplyConfiguration(new RebateDbMapping());
			modelBuilder.ApplyConfiguration(new RebateCalculationDbMapping());

			base.OnModelCreating(modelBuilder);
		}
	}
}
