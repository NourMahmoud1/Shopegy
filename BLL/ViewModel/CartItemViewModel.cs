using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModel
{
	public class CartItemViewModel
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice => Price * Quantity;
		public CartItemViewModel(int productId, string productName, string imageUrl, decimal price, int quantity)
		{
			ProductId = productId;
			ProductName = productName;
			ImageUrl = imageUrl;
			Price = price;
			Quantity = quantity;
		}
	}
}
