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
		public async Task<IActionResult> Insert()
		{
			ProductWithListOfCatesViewModel product = new();
			product.categories = await unitof.ProductCategories.GetAllAsync();
			return View(product);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> InsertAsync(ProductWithListOfCatesViewModel product)
		{

			if (ModelState.IsValid)
			{
				string uploadpath = Path.Combine(_webHostEnvironment.WebRootPath, "img");
				string imagename = Guid.NewGuid().ToString() + "_" + product.image.FileName;
				string filepath = Path.Combine(uploadpath, imagename);
				using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
				{
					product.image.CopyTo(fileStream);
				}
				product.ImageUrl = imagename;

				await unitof.Products.InsertAsync(product);
				unitof.Save();
				return RedirectToAction("products", "Dashboard");
			}

			return View(product);
		}

	}
}
