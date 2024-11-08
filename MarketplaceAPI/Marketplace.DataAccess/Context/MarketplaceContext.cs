using Marketplace.DataAccess.Common.Models;
using Marketplace.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.DataAccess.Context
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<CarDb> Cars { get; set; }

        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CarConfiguration());
        }
    }
}