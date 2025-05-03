using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//namespace Shopegy.Models
namespace Shopegy.Models
{
    public class ProductReivew
    {
        public int ID { get; set; }

        public decimal Rating { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;

		//navigation property for product

		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public Product? Product { get; set; }
        //navigation property for user
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User? User { get; set; }
    }
}