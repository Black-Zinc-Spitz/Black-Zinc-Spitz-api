using System.Collections.Generic;
using System.Linq;

namespace Jet.Piranha.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice => Items.Sum(i => i.Price);

    }

    public class OrderItem
    {
        public int Id { get; set; }
        public OrderItem Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price => Item.Price * Quantity;
    }
}

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
        { }
        public DbSet<Items> Items { get; set; }

        public DbSet<Order> Orders { get; set; }
}