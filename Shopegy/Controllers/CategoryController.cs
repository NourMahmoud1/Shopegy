using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopegy.Models;

namespace Shopegy.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IUnitofWork unitof;

		public CategoryController(IWebHostEnvironment webHostEnvironment, IUnitofWork unitof)
		{
			_webHostEnvironment = webHostEnvironment;
			this.unitof = unitof;
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
			return View();
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> InsertAsync(ProductCategorie category)
		{
			string uploadpath = Path.Combine(_webHostEnvironment.WebRootPath, "img");
			string imagename = Guid.NewGuid().ToString() + "_" + category.image.FileName;
			string filepath = Path.Combine(uploadpath, imagename);
			using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
			{
				category.image.CopyTo(fileStream);
			}
			category.ImageUrl = imagename;

			if (ModelState.IsValid)
			{
				await unitof.ProductCategories.AddAsync(category);
				unitof.Save();

				

				return RedirectToAction("categories", "dashboard");
			}

			return View(category);
		}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var category = unitof.ProductCategories.GetById(id);
            if (category == null)
                return NotFound();

            unitof.ProductCategories.Delete(category);
            unitof.Save();
            return RedirectToAction("Insert");
        }
        //--------------------------------------------

    }
}
