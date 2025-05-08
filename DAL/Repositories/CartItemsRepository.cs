using BLL.Interfaces;
using BLL.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	internal class CartItemsRepository: Repository<CartItem>, ICartItemsRepository
	{
		private readonly ShopegyAppContext _context;
		public CartItemsRepository(ShopegyAppContext context) : base(context)
		{
			_context = context;
		}
		public async Task<CartItem> GetByProductId(int cartId, int productId)
		{
			return await _context.Set<CartItem>()
				.Include(ci => ci.Product) 
				.FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);
		}
	}
	
}
