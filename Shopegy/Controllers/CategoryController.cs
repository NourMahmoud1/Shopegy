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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Insert()
        {
            return View(new ProductCategorie()); // ✅ حل المشكلة
        }
        //--------------------------------------------

  //      [HttpGet]
		//[Authorize(Roles = "Admin")]

		//public IActionResult Insert()
		//{
		//	return View();
		//}

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
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            var category = await unitof.ProductCategories.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return View("Insert", category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpDate(ProductCategorie category)
        {
            if (category.ProductCategorieID <= 0)
            {
                ModelState.AddModelError("ProductCategorieID", "معرف الفئة غير صالح");
            }

            if (!ModelState.IsValid)
            {
                return View("Insert", category);
            }

            var existing = await unitof.ProductCategories.GetByIdAsync(category.ProductCategorieID);
            if (existing == null)
                return NotFound();

            existing.Name = category.Name;
            existing.Description = category.Description;
            if (category.image != null)
            {
                string uploadpath = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                string imagename = Guid.NewGuid().ToString() + "_" + category.image.FileName;
                string filepath = Path.Combine(uploadpath, imagename);
                using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                {
                    await category.image.CopyToAsync(fileStream);
                }
                existing.ImageUrl = imagename;
            }

            unitof.ProductCategories.Update(existing);
            unitof.Save();

            return RedirectToAction("categories", "Dashboard");
        }

    }
}
