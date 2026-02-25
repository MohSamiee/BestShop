using Microsoft.AspNetCore.Mvc;

namespace BestShop.Web.Controllers;
public class AccountController : Controller
{

	#region Constructor
	private readonly IAccountService _accountService;

	public AccountController(IAccountService accountService)
	{
		_accountService = accountService;
	}
	#endregion Constructor

	#region Register
	[HttpGet("/Register")]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost("/Register")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register(RegisterViewModel vm)
	{
		if (!true)
			return View();
		var result =await _accountService.RegisterUserAsync(vm);

		return View();
	}

	#endregion Register
}
