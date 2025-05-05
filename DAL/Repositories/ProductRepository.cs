using BLL.Interfaces;
using BLL.ViewModel;
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
		public async Task InsertAsync(ProductWithListOfCatesViewModel p)
		{
			Product product = new()
			{
				ProductID = p.Id,
				Name = p.Name,
				Color = p.Color,
				Description = p.Description,
				ImageUrl = p.ImageUrl,
				Price = p.Price,
				Quantity = p.Quantity,
				Rating = p.Rating,
				ProductCategorieID = p.CategoryId
			};

			await AddAsync(product);
		}
	} 
}
