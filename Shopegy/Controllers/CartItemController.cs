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

		public async Task<IActionResult> UpdateQuantityByOne(int id)
		{
			CartItem cartItem = await _unitofWork.CartItems.GetByIdAsync(id);
			if (cartItem == null)
			{
				return NotFound();
			}
			cartItem.Quantity++;
			_unitofWork.CartItems.Update(cartItem);
			_unitofWork.Save();
			return RedirectToAction("Index", "Cart");
		}
		public async Task<IActionResult> UpdateQuantityByMinusOne(int id)
		{
			CartItem cartItem = await _unitofWork.CartItems.GetByIdAsync(id);
			if (cartItem == null)
			{
				return NotFound();
			}
			cartItem.Quantity--;
			_unitofWork.CartItems.Update(cartItem);
			_unitofWork.Save();
			return RedirectToAction("Index", "Cart");
		}
	}
}
