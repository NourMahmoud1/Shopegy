using BLL.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Shopegy.Controllers
{
	public class CartItemController : Controller
	{
		private readonly IUnitofWork _unitofWork;
		public CartItemController(IUnitofWork unitofWork)
		{
			_unitofWork = unitofWork;
		}
		public async Task<IActionResult> Delete(int id)
		{
			CartItem cartItem = await _unitofWork.CartItems.GetByIdAsync(id);
			if (cartItem == null)
			{
				return NotFound();
			}
			_unitofWork.CartItems.Delete(cartItem);
			_unitofWork.Save();
			return RedirectToAction("Index", "Cart");

		}
	}
}
