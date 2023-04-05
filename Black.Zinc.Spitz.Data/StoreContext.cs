using Black.Zinc.Spitz.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Black.Zinc.Spitz.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
        {}

        public DbSet<InvalidTimeZoneException> Items { get; set; }
    }
}
