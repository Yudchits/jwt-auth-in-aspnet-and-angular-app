using Marketplace.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.DataAccess.Configurations
{
    public class EngineConfiguration : IEntityTypeConfiguration<EngineDb>
    {
        public void Configure(EntityTypeBuilder<EngineDb> builder)
        {
            builder.ToTable("Engines");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FuelType)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.Capacity)
                .IsRequired();

            builder.Property(e => e.Power)
                .IsRequired();
        }
    }
}