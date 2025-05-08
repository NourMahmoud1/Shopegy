using BLL.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface ICartItemsRepository : IRepository<CartItem>
	{

		public Task<CartItem> GetByProductId(int cartId, int productId);
		
		public List<CartItem> GetAllCartItem(Func<CartItem,bool> where, string? include);
	}
}
