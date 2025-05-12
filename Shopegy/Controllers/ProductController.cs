using BLL.Models;
using BLL.ViewModel;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopegy.Models;
using System.Security.Claims;

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
		//--------------------------------------------------
		//[HttpPost]
		public async Task<IActionResult> AddtoCart(int id, int quantity = 1)
		{
			// check if the user is authenticated
			if (User.Identity.IsAuthenticated)
			{
				// get the user id
				var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
				// check if the cart exists for the user
				var cart = await unitof.Carts.GetCartByUserId(userId);
				if (cart == null)
				{
					cart = new Cart();
					cart.UserId =userId;
					await unitof.Carts.AddAsync(cart);
					unitof.Save();
				}
				// check if the product exists in the cart
				var cartItem = await unitof.CartItems.GetByProductId(cart.Id, id);
				if (cartItem == null)		
				{
					cartItem = new CartItem();
					cartItem.ProductId = id;
					cartItem.Quantity = quantity;
					cartItem.CartId = cart.Id;
					await unitof.CartItems.AddAsync(cartItem);
					unitof.Save();
				}
				else
				{
					cartItem.Quantity += quantity;
					unitof.CartItems.Update(cartItem);
					unitof.Save();
				}
				//}
				return RedirectToAction("Index", "Home");
			}
			else
			{
				// if the user is not authenticated, redirect to the login page
				return RedirectToAction("Login", "Account");
			}

		}
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await unitof.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            unitof.Products.Delete(product);
            unitof.Save();

            return RedirectToAction("products", "Dashboard");
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            var product = await unitof.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            var viewModel = new ProductWithListOfCatesViewModel
            {
                Id = product.ProductID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.ProductCategorieID,
                Rating = product.Rating,
                Color = product.Color,
                ImageUrl = product.ImageUrl,
                categories = await unitof.ProductCategories.GetAllAsync()
            };

            return View("Insert", viewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpDate(ProductWithListOfCatesViewModel product)
        {
            if (product.Id <= 0)
            {
                ModelState.AddModelError("Id", "معرف المنتج غير صالح");
            }

            if (!ModelState.IsValid)
            {
                product.categories = await unitof.ProductCategories.GetAllAsync();
                return View("Insert", product);
            }

            var existing = await unitof.Products.GetByIdAsync(product.Id);
            if (existing == null)
                return NotFound();

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;
            existing.ProductCategorieID = product.CategoryId; // تحديث الفئة
            existing.Rating = product.Rating;
            existing.Color = product.Color;

            unitof.Products.Update(existing);
            unitof.Save();

            return RedirectToAction("products", "Dashboard");
        }
		//------------------------------------------
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var product = await unitof.Products.GetByIdAsync(id);
			if (product == null)
				return NotFound();
			var viewModel = new ProductWithListOfCatesViewModel
			{
				Id = product.ProductID,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Quantity = product.Quantity,
				Color = product.Color,
				ImageUrl = product.ImageUrl,
				Rating = product.Rating
			};
			return View(viewModel);
		}


	}
}
