using Black.Zinc.Spitz.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Black.Zinc.Spitz.Data
{
public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    { }

    public DbSet<Item> Items { get; set; } 

    protected override void OnModelCreating (ModelBuilder builder) 
    {
        base.OnModelCreating(builder);
        DbIntializer.Intialize(builder);

    }
 
}
}