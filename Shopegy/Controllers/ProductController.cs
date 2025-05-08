using BLL.Models;
using BLL.ViewModel;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
	}
}
