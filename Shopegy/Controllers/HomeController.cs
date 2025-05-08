using System.Diagnostics;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shopegy.Models;

namespace Shopegy.Controllers;

public class HomeController : Controller
{
    private readonly IUnitofWork _unitofWork;
    public HomeController(IUnitofWork unitofWork)
    {

        _unitofWork = unitofWork;
    }

    public IActionResult Index()
    {
        var categories = _unitofWork.ProductCategories.GetAll();
        return View(categories);
    }

	


}
