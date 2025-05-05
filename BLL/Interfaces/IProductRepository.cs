using BLL.ViewModel;
using Interfaces;
using Shopegy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IProductRepository : IRepository<Product>
	{
		public Task InsertAsync(ProductWithListOfCatesViewModel p);
	}
}
