using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smartwyre.DeveloperTest.Entities;

namespace Smartwyre.DeveloperTest.Data.Mappings
{
	internal class RebateCalculationDbMapping : IEntityTypeConfiguration<RebateCalculation>
	{
		public void Configure(EntityTypeBuilder<RebateCalculation> builder)
		{
			builder.ToTable(nameof(Product));

			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Property(p => p.ProductIdentifier).HasMaxLength(128);
			builder.Property(p => p.RebateIdentifier).HasMaxLength(128);
		}
	}
}
