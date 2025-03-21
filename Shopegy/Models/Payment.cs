using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopegy.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public int Amount { get; set; }

        [MaxLength(50)]
        public required string PaymentMethod { get; set; }

        [MaxLength(50)]
        public required string Status { get; set; }

        // Navigation property for the related Order
        [ForeignKey("OrderID")]
        public required Order Order { get; set; }
    }
}