using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB.Controllers
{
	public class LoginController : Controller
	{
		private IAuthService _authService;
	

		public LoginController(IAuthService authService)
		{
			_authService = authService;
		
		}


		[HttpGet]   // sayfa yüklenince
		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public ActionResult Login(UserForLoginDto userForLoginDto)
		{
			var userToLogin = _authService.Login(userForLoginDto);
			if (!userToLogin.Success)
			{
				return BadRequest(userToLogin.Message);
			}

			var result = _authService.CreateAccessToken(userToLogin.Data);
			if (result.Success)
			{
				return RedirectToAction("Profile", "Profile");
			}

			return BadRequest(result.Message);
		}


	

	}
}
