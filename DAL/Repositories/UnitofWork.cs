using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Repositories;
using Data;
using Interfaces;
using Shopegy.Models;

namespace Repositories;

public class UnitofWork : IUnitofWork
{

    private readonly ShopegyAppContext _context;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IProductCategorieRepository> _productCategorieRepository;
	private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IOrderItemRepository> _orderItemRepository;
	private readonly Lazy<IProductReviewRepository> _productReviewRepository;
	private readonly Lazy<ICartRepository> _cartRepository;
	private readonly Lazy<ICartItemsRepository> _cartItemsRepository;
	public UnitofWork(ShopegyAppContext context)
    {
        _context = context;
		_productRepository = new Lazy<IProductRepository>(new ProductRepository(_context));
        _productCategorieRepository = new Lazy<IProductCategorieRepository>(new ProductCategorieRepository(_context));
		_orderRepository = new Lazy<IOrderRepository>(new OrderRepository(_context));
		_orderItemRepository = new Lazy<IOrderItemRepository>(new OrderItemRepository(_context));
		_productReviewRepository = new Lazy<IProductReviewRepository>(new ProductReivewRepository(_context));
		_cartRepository = new Lazy<ICartRepository>(new CartRepository(_context));
		_cartItemsRepository = new Lazy<ICartItemsRepository>(new CartItemsRepository(_context));
	}
    public IProductRepository Products => _productRepository.Value;
	public IProductCategorieRepository ProductCategories => _productCategorieRepository.Value;
	public ICartRepository Carts => _cartRepository.Value;
	public ICartItemsRepository CartItems => _cartItemsRepository.Value;
	public IOrderRepository Orders => _orderRepository.Value;

	public IOrderItemRepository OrderItems => _orderItemRepository.Value;

	public IProductReviewRepository ProductReviews => _productReviewRepository.Value;

	public IRepository<Shipping> Shipping { get; }

	public IRepository<ShippingAddress> ShippingAddresses { get; }

	//public IRepository<ApplicationUser> Users { get; }

	public void Dispose()
    { 
        _context.Dispose();
    }

    public int Save()
    {
       return _context.SaveChanges();
    }
}
