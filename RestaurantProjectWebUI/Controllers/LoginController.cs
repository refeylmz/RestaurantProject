using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.EntityLayer.Entities;
using RestaurantProjectWebUI.Dtos.IdentityDtos;

namespace RestaurantProjectWebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index","Default");
			}
			else
			{
				ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
				return View();
			}

		}
	}
}
