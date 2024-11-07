using Microsoft.EntityFrameworkCore;

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
        }
    }
}
