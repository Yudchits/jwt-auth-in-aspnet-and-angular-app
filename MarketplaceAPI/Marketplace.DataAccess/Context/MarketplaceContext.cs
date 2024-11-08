using Microsoft.EntityFrameworkCore;

namespace Marketplace.DataAccess.Context
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options)
        {
        }
    }
}