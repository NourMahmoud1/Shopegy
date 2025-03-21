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
		public string Image { get; set; }
		public DateTime Created_at { get; set; } = DateTime.Now;
		public DateTime Updated_at { get; set; } = DateTime.Now;



		//navigation property for ProductCategorie
		[ForeignKey("ProductCategorie")]
		public int ProductCategorieID { get; set; }
		public ProductCategorie ProductCategorie { get; set; }

		// navigation property for product review
		[ForeignKey("ProductReivew")]
		public int ProductReivewId { get; set; }
		public ProductReivew ProductReivew { get; set; }
	}
}
