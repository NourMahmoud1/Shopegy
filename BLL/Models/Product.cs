using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopegy.Models
{
	public class Product
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		//public float length { get; set; }
		public string Stock { get; set; }
		public string ImageUrl { get; set; } = "wwwroot/images/sfdsdf";  // default image

		public DateTime Created_at { get; set; } = DateTime.Now;
		public DateTime Updated_at { get; set; } = DateTime.Now;

		public int Quantity { get; set; }

		public string Color { get; set; }

		//navigation property for ProductCategorie
		[ForeignKey("ProductCategorie")]
		public int ProductCategorieID { get; set; }
		public ProductCategorie ProductCategorie { get; set; }

		// navigation property for product review
		public ICollection<ProductReivew> ProductReivews { get; set; }
	}
}
