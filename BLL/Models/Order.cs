using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopegy.Models
{
	public class Order
	{
		[Key]
		public int OrderID { get; set; }

		[Required]
		[DataType(DataType.Date)]  // In this case we only want to keep track of the date, not the date and time
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  // specifies that the formatting should also be applied when the value is displayed in a text box for editing

		public DateTime OrderDate { get; set; }

		public int? TotalAmount { get; set; }

		[Required]
		[DataType(DataType.Date)]
        public DateTime created_at { get; set; }
		[DataType(DataType.Date)]
		public DateTime? updated_at { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

		[ForeignKey("User")]
		public string ApplicationUserId { get; set; }

		public ApplicationUser? User { get; set; }

		// Navigation property for Payments
		public ICollection<Payment>? Payments { get; set; }
		[ForeignKey("Shipment")]
		public int? ShipmentId { get; set; }

		public Shipping? Shipment { get; set; }

	}
}