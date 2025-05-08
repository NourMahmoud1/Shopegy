using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
	public class Cart
	{
		public int Id { get; set; }
		//UserId
		[ForeignKey("User")]
		public string UserId { get; set; }
		public ApplicationUser? User { get; set; }

		public List<CartItem>? CartItems { get; set; }
		public decimal TotalPrice { get; set; }

	}
}
