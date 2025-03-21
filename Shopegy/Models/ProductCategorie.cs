namespace Shopegy.Models
{
	public class ProductCategorie
	{
		public int ProductCategorieID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public DateTime Created_at { get; set; } = DateTime.Now;
		public DateTime Updated_at { get; set; } = DateTime.Now;

		public ICollection<Product> Products { get; set; }

	}
}
