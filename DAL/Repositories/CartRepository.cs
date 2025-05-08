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
	internal class CartRepository : Repository<Cart>, ICartRepository
	{
		private readonly ShopegyAppContext _context;
		public CartRepository(ShopegyAppContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Cart> GetCartByUserId(string userId)
		{
			return await _context.Set<Cart>()
				.Include(c => c.User) // Include related User entity if needed
				.FirstOrDefaultAsync(c => c.UserId == userId);
		}

	}
}
