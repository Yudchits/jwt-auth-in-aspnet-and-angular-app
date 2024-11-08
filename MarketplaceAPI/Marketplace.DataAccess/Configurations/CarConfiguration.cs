using Marketplace.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.DataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<CarDb>
    {
        public void Configure(EntityTypeBuilder<CarDb> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Brand)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.Model)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.Generation)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.FuelType)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.EngineCapacity)
                .HasPrecision(3, 1)
                .IsRequired();

            builder.Property(c => c.EnginePower)
                .IsRequired();

            builder.Property(c => c.DriveSystem)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.Transmission)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(c => c.Photo)
                .IsRequired();
        }
    }
}