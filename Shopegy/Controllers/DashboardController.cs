using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopegy.Models;

namespace Shopegy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class DashboardController : Controller
	{
		private IUnitofWork _unitofWork;

		public DashboardController(IUnitofWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		public IActionResult Index()
		{
			return View();
		}






		public IActionResult getOrdersPartial()
		{
			List<Order> orders = _unitofWork.Orders.GetAll("User");

			return PartialView("_getOrdersPartial", orders);
		}
	}
}
