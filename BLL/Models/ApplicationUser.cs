using Microsoft.AspNetCore.Identity;
using Shopegy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? PostalCode { get; set; }
		public string? Country { get; set; }
		public List<Cart>? Carts { get; set; }
		public List<Payment>? Payments { get; set; }
		public List<Shipping>? Shippings { get; set; }
		public List<Order>? Orders { get; set; }
	}
	
}
