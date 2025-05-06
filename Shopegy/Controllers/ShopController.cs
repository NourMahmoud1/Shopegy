//using Microsoft.AspNetCore.Mvc;

//namespace Shopegy.Controllers
//{
//	public class ShopController : Controller
//	{
//		public IActionResult Index()
//		{

//			return View();
//		}
//	}
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopegy.Models;
using Data;
using Interfaces;

namespace Shopegy.Controllers
{
    public class ShopController : Controller
    {
        
        private readonly IUnitofWork _unitofWork;
		public ShopController(IUnitofWork unitofWork)
		{
			
			_unitofWork = unitofWork;
		}

		// Action لعرض كل المنتجات في الصفحة الرئيسية للمحل
		public async Task<IActionResult> Index()
        {
            var products = await _unitofWork.Products.GetAllAsync();

			return View(products);
        }
        //public IActionResult GetProducts()
        //{
        //    var products = _context.Products
        //                           .Include(p => p.ProductCategorie)
        //                           .ToList();
        //    return PartialView("_ProductList", products);
        //}

    }
}
