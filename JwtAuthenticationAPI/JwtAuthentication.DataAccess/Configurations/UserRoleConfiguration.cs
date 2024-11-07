using JwtAuthentication.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAuthentication.DataAccess.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleDb>
    {
        public void Configure(EntityTypeBuilder<UserRoleDb> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Property(ur => ur.UserId)
                .ValueGeneratedNever();

            builder.Property(ur => ur.RoleId)
                .ValueGeneratedNever();

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}