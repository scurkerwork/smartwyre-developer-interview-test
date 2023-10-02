using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smartwyre.DeveloperTest.Entities;

namespace Smartwyre.DeveloperTest.Data.Mappings
{
	public class RebateDbMapping : IEntityTypeConfiguration<Rebate>
	{
		public void Configure(EntityTypeBuilder<Rebate> builder)
		{
			builder.ToTable(nameof(Rebate));

			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Property(p => p.Identifier).HasMaxLength(128);
		}
	}
}
