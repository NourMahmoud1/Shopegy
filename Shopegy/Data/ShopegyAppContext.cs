using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class ShopegyAppContext : DbContext
{
    public ShopegyAppContext(DbContextOptions<ShopegyAppContext> options) : base(options)
    {

    }
    public DbSet<Shipping> Shipping { get; set; }
    public DbSet<ShippingAddress> ShippingAddress { get; set; }
}
