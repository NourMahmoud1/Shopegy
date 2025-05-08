using BLL.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface ICartRepository : IRepository<Cart>
	{
		public  Task<Cart> GetCartByUserId(string userId);
	}
}
