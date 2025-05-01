namespace Shopegy.Models;

public class OrderItem
{
    public int OrderItemID { get; set; }
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    //public decimal? Discount { get; set; }

    //  OrderID Foreign Key linking to Order
    //ProductID Foreign Key linking to Product 
    public Order Order { get; set; }
    public Product Product { get; set; }
}
