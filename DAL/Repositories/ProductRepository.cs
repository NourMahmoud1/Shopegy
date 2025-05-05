using BLL.Interfaces;
using Data;
using Repositories;
using Shopegy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	internal class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(ShopegyAppContext context) : base(context)
		{
		}
	} 
}
