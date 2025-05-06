using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shopegy.Models;

namespace Shopegy.Controllers;

public class HomeController : Controller
{
	
	public IActionResult Index()
	{
		return View();
	}


}
