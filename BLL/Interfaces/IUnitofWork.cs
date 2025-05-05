using BLL.Models;
using Shopegy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace  Interfaces;

public interface IUnitofWork:IDisposable
{

	public IRepository<Product> Products { get; }

	public IRepository<ProductCategorie> ProductCategories { get; }

	public IRepository<Order> Orders { get; }
	public IRepository<OrderItem> OrderItems { get; }
	public IRepository<ProductReivew> ProductReviews { get; }

	public IRepository<Shipping> Shipping { get; }
	public IRepository<ShippingAddress> ShippingAddresses { get; }
	public IRepository<ApplicationUser> ApplicationUsers { get; }

	int Save();

	void Dispose();
}
