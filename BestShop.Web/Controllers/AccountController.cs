using BestShop.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace BestShop.Web.Controllers;
public class AccountController : Controller
{
	#region Register
	[HttpGet("/Register")]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost("/Register")]
	[ValidateAntiForgeryToken]
	public IActionResult Register(RegisterViewModel vm)
	{
		return View();
	}

	#endregion Register
}
