using BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BLL.ViewModel;
using Shopegy.Models;

namespace Shopegy.Controllers
{
	public class AccountController : Controller
	{

		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterUserViewModel userViewModel)
		{
			if (ModelState.IsValid)
			{
				// Logic to register the user
				// For example, save the user to the database
				// Redirect to a success page or login page
				ApplicationUser appUser = new ApplicationUser
				{
					UserName = userViewModel.UserName,
					Email = userViewModel.Email,
					Address = userViewModel.Address
				};

				IdentityResult result = await _userManager.CreateAsync(appUser, userViewModel.Password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(appUser, "User");
					//create a cookie

					await _signInManager.SignInAsync(appUser, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View("Register", userViewModel);
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser user = await _userManager.FindByNameAsync(loginViewModel.UserName);
				if (user != null)
				{
					bool found = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
					if (found)
					{
						// cookie
						await _signInManager.SignInAsync(user, isPersistent: loginViewModel.RememberMe);
						// Redirect to the desired page after successful login
						if (await _userManager.IsInRoleAsync(user, "Admin"))
						{
							return RedirectToAction("Index", "Dashboard");
						}
						else if (await _userManager.IsInRoleAsync(user, "User"))
						{
							return RedirectToAction("Index", "Home");
						}
					}
				}
				ModelState.AddModelError(string.Empty, "User not found.");
			}
			return View("Login", loginViewModel);
		}
		public async Task<IActionResult> confirmMakeAdmin(string userName)
		{
			ApplicationUser user = await _userManager.FindByNameAsync(userName);
			if (user != null)
			{
				await _userManager.RemoveFromRoleAsync(user, "User");
				await _userManager.AddToRoleAsync(user, "Admin");
				return RedirectToAction("index", "Dashborard");
			}
			return RedirectToAction("Register", "Account");
		}
		public async Task<IActionResult> Logout()
		{
			// Logic to log out the user
			await _signInManager.SignOutAsync();
			
			return RedirectToAction("Login", "Account");
		}
	}
}
