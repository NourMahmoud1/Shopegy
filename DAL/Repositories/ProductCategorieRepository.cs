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
	internal class ProductCategorieRepository : Repository<ProductCategorie>, IProductCategorieRepository
	{
		public ProductCategorieRepository(ShopegyAppContext context) : base(context)
		{
		}
	}
	
}
