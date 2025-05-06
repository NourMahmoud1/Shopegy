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

namespace Shopegy.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopegyAppContext _context;

        public ShopController(ShopegyAppContext context)
        {
            _context = context;
        }

        // Action لعرض كل المنتجات في الصفحة الرئيسية للمحل
        public IActionResult Index()
        {
            var products = _context.Products
                .Include(p => p.ProductCategorie) // لو حابب تجيب التصنيف مع المنتج
                .ToList();

            return View(products);
        }
        public IActionResult GetProducts()
        {
            var products = _context.Products
                                   .Include(p => p.ProductCategorie)
                                   .ToList();
            return PartialView("_ProductList", products);
        }

    }
}
