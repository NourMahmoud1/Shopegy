using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopegy.Models
{
	public class ProductCategorie
	{
		public int ProductCategorieID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Created_at { get; set; } = DateTime.Now;
		public DateTime Updated_at { get; set; } = DateTime.Now;
		public string ImageUrl { get; set; } = "wwwroot/images/CatDefault.png";
		[NotMapped]
        public IFormFile image { get; set; }
		public List<Product>? Products { get; set; }

	}
}
