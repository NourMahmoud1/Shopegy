namespace Models;

 public class Shipping
{
    public int ShippingId { get; set; }
    public int OrderId { get; set; }
    public string ShppingAddressId { get; set; }
    public string ShippingDate { get; set; }
    public int TrackingNumber { get; set; }
    public string Status { get; set; }
}