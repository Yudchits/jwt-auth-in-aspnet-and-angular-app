using JwtAuthentication.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JwtAuthentication.DataAccess.Context
{
    public class JwtAuthenticationContext : DbContext
    {
        public JwtAuthenticationContext(DbContextOptions<JwtAuthenticationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
