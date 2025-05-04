using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModel
{
	public class RegisterUserViewModel
	{
		[Required(ErrorMessage = "UserName is required")]
		[Display(Name = "User Name")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is required")]
		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Address is required")]
		[Display(Name = "Address")]
		public string Address { get; set; }
	}
}
