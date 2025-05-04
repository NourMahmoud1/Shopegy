using Microsoft.AspNetCore.Mvc;

namespace Shopegy.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
