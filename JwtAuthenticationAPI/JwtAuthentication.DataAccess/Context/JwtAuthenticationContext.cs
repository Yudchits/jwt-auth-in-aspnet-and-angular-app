using JwtAuthentication.DataAccess.Common.Models;
using JwtAuthentication.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.DataAccess.Context
{
    public class JwtAuthenticationContext : DbContext
    {
        public DbSet<UserDb> Users { get; set; }
        public DbSet<RoleDb> Roles { get; set; }
        public DbSet<UserRoleDb> UserRoles { get; set; }

        public JwtAuthenticationContext(DbContextOptions<JwtAuthenticationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
