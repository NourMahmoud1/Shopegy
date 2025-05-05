using BLL.ViewModel;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Shopegy.Controllers
{
	public class ProductController : Controller
	{
		private readonly IUnitofWork unitof;
		private readonly IWebHostEnvironment _webHostEnvironment;


		public ProductController(IUnitofWork unitof, IWebHostEnvironment webHostEnvironment)
		{
			this.unitof = unitof;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			return View();
		}

		//--------------------------------------------

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult Insert()
		{
			ProductWithListOfCatesViewModel product = new();
			product.categories = unitof.ProductCategories.GetAll();
			return View(product);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> InsertAsync(ProductWithListOfCatesViewModel product)
		{
			string uploadpath = Path.Combine(_webHostEnvironment.WebRootPath, "img");
			string imagename = Guid.NewGuid().ToString() + "_" + product.image.FileName;
			string filepath = Path.Combine(uploadpath, imagename);
			using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
			{
				product.image.CopyTo(fileStream);
			}
			product.ImageUrl = imagename;

			if (ModelState.IsValid)
			{

				await unitof.Products.InsertAsync(product);
				unitof.Save();
				return RedirectToAction("products", "Dashboard");
			}

			return View(product);
		}

	}
}
