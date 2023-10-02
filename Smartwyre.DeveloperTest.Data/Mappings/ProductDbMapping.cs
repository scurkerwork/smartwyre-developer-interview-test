using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smartwyre.DeveloperTest.Entities;

namespace Smartwyre.DeveloperTest.Data.Mappings
{
	public class ProductDbMapping : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable(nameof(Product));

			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Property(p => p.Identifier).HasMaxLength(128);
			builder.Property(p => p.Uom).HasMaxLength(128);
		}
	}
}
