using BLL.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopegy.Models;

namespace Shopegy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class DashboardController : Controller
	{
		private IUnitofWork _unitofWork;
		private readonly UserManager<ApplicationUser> userManager;

		public DashboardController(IUnitofWork unitofWork,
            UserManager<ApplicationUser> userManager
			)
		{
			_unitofWork = unitofWork;
			this.userManager = userManager;

		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Products()
		{
			List<Product> products = _unitofWork.Products.GetAll();
			return View(products);
		}




		public IActionResult getOrdersPartial()
		{
			List<Order> orders = _unitofWork.Orders.GetAll("User");

			return PartialView("_getOrdersPartial", orders);
		}
		public IActionResult numberOfUsers()
		{
			int users = userManager.Users.Count();
			return Json(users);
		}
		public IActionResult numOfProducts()
		{
			int prods = _unitofWork.Products.GetAll().Count();
			return Json(prods);
		}
	}
}
