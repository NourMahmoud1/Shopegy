using BLL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopegy.Models;

 public class Shipping
{
    public int ShippingId { get; set; }
    public DateTime ShippingDate { get; set; }
    public string TrackingNumber { get; set; }
    public string Status { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now;

    public int ShippingAddressId { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    
    public int OrderID { get; set; }
    public Order Order { get; set; }
	[ForeignKey("User")]
	public string UserId { get; set; }

	public ApplicationUser? User { get; set; }

}