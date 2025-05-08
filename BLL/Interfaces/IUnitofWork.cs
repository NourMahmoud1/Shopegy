using BLL.Interfaces;
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

	public IProductRepository Products { get; }

	public IProductCategorieRepository ProductCategories { get; }
	public ICartRepository Carts { get; }
	public ICartItemsRepository CartItems { get; }
	public IOrderRepository Orders { get; }
	public IOrderItemRepository OrderItems { get; }
	public IProductReviewRepository ProductReviews { get; }

	public IRepository<Shipping> Shipping { get; }
	public IRepository<ShippingAddress> ShippingAddresses { get; }
	//public IRepository<ApplicationUser> Users { get; }

	int Save();

	void Dispose();
}
