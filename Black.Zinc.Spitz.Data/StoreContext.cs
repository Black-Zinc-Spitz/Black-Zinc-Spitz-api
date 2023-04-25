using Black.Zinc.Spitz.Domain.Catalog;
using Black.Zinc.Spitz.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Black.Zinc.Spitz.Data
{
public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    { }

    public DbSet<Item> Items { get; set; } 

    public DbSet<Order> Orders { get; set; } 

    protected override void OnModelCreating (ModelBuilder builder) 
    {
        base.OnModelCreating(builder);
        DbIntializer.Intialize(builder);

    }
 
}
}
