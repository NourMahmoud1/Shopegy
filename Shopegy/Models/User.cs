using System.ComponentModel.DataAnnotations;

namespace Shopegy.Models
{
    public class User
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        public string? Preferences { get; set; }
        public string? RememberToken { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CartId { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; } ;
        public ICollection<ProductReivew> productreivew { get; set; };
        public ICollection<ShippingAddress> ShippingAddresses { get; set; };
        public DbSet<Order> Orders { get; set; };
    }
}
