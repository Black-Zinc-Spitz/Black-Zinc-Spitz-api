using Black.Zinc.Spitz.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Black.Zinc.Spitz.Data
{
    public static class DbIntializer
    {
        public static void Intialize(ModelBuilder builder) 
        {
            builder.Entity<Item>().HasData(
                new Item("Shirt", "Ohio State shirt", "Nike", 29.99M)
                {
                    Id = 1
                },
                new Item("Shirt", "Ohio State shorts", "Nike", 44.99M)
                {
                    Id = 2
                }
            );
        }
    }
}