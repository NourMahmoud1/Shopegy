using BLL.Models;
using BLL.ViewModel;
using Humanizer;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Security.Claims;

namespace Shopegy.Controllers
{
	public class CartController : Controller
	{
		private readonly IUnitofWork _unitofWork;
		public CartController(IUnitofWork unitofWork)
		{
			_unitofWork = unitofWork;
		}
		public async Task<IActionResult> Index()
		{
			//List<CartItem> cartItems = _unitofWork.CartItems.GetAll("Product");
			// Get the user ID
			string userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

			ViewBag.UserId = userIdClaim;
			//get the cart id for this user
			var cart = await _unitofWork.Carts.GetCartByUserId(userIdClaim);
			if (cart == null)
			{
				return View(new List<CartItemViewModel>());
			}
			// Get the cart items for this cart
			var cartItems = _unitofWork.CartItems.GetAllCartItem(x => x.CartId == cart.Id, "Product");
			List<CartItemViewModel> cartItemViewModels = new List<CartItemViewModel>();
			foreach (var item in cartItems)
			{
				CartItemViewModel cartItemViewModel = new CartItemViewModel(item.ProductId, item.Product.Name, item.Product.ImageUrl, item.Product.Price, item.Quantity);

				cartItemViewModels.Add(cartItemViewModel);
			}
			return View(cartItemViewModels);

		}
	}
}
