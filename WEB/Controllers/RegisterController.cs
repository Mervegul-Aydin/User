using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
	public class RegisterController : Controller
	{
		private IAuthService _authService;

		public RegisterController(IAuthService authService)
		{
			_authService = authService;
		}


		[HttpGet]   // sayfa yüklenince
		public IActionResult Register()
		{
			return View();
		}

				
		[HttpPost]
		public ActionResult Register(UserForRegisterDto userForRegisterDto)
		{
			var userExists = _authService.UserExists(userForRegisterDto.Email);
			if (!userExists.Success)
			{
				return BadRequest(userExists.Message);
			}

			var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
			var result = _authService.CreateAccessToken(registerResult.Data);
			if (result.Success)
			{
				return RedirectToAction("Login", "Login");
			}

			return RedirectToAction("Login","Login");
		}
	}
}
