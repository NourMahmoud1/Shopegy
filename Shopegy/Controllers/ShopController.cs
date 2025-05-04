using Microsoft.AspNetCore.Mvc;

namespace Shopegy.Controllers
{
	public class ShopController : Controller
	{
		public IActionResult Index()
		{

			return View();
		}
	}
}
