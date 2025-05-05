using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using Data;
using Interfaces;
using Shopegy.Models;

namespace Repositories;

public class UnitofWork : IUnitofWork
{
    private readonly ShopegyAppContext _context;

    public UnitofWork(ShopegyAppContext context)
    {
        _context = context;
        Products = new Repository<Product>(_context);
		ProductCategories = new Repository<ProductCategorie>(_context);
    }
    public IRepository<Product> Products { get; }
    public IRepository<ProductCategorie> ProductCategories { get; }

	public IRepository<Order> Orders { get; }

	public IRepository<OrderItem> OrderItems { get; }

	public IRepository<ProductReivew> ProductReviews { get; }

	public IRepository<Shipping> Shipping { get; }

	public IRepository<ShippingAddress> ShippingAddresses { get; }

	public IRepository<ApplicationUser> Users { get; }

	public void Dispose()
    { 
        _context.Dispose();
    }

    public int Save()
    {
       return _context.SaveChanges();
    }
}
