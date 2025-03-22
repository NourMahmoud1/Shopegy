using System.ComponentModel.DataAnnotations.Schema;

namespace Shopegy.Models;

public class ShippingAddress
{
    public int ShippingAddressId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public Shipping Shipping { get; set; }
    [ForeignKey("User")]
    public int UserID { get; set; }
    public User User { get; set; }
}
