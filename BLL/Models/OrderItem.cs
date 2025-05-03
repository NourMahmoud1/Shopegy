using System.ComponentModel.DataAnnotations.Schema;

namespace Shopegy.Models;

public class OrderItem
{
    public int OrderItemID { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }

	//public decimal? Discount { get; set; }

	//  OrderID Foreign Key linking to Order
	//ProductID Foreign Key linking to Product 
	[ForeignKey("Order")]
	public int OrderId { get; set; }

	public Order Order { get; set; }
	[ForeignKey("Product")]
	public int ProductId { get; set; }

	public Product Product { get; set; }
}
