using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopegy.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

       

        [Required]
        public DateTime OrderDate { get; set; }

        public int? TotalAmount { get; set; }

        [Required]
        public DateTime created_at { get; set; }

        public DateTime? updated_at { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        // Navigation property for Payments
        public ICollection<Payment>? Payments { get; set; }
        // Navigation property for shipping 
        public ICollection<Shipping>? Shipping { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User? User { get; set; }
    }
}