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

	public IActionResult Index()
	{
		return View("SuccessRegister");
	}
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
		var result = await _accountService.RegisterUserAsync(vm);
		if (!result.IsSuccess && result.ModelStateErrors != null && result.ModelStateErrors.Any())
		{
			foreach (var error in result.ModelStateErrors)
			{
				ModelState.AddModelError(error.ModelStateField, error.ModelStateErrorMessage);
			}
		}
		if (!result.IsSuccess) return View(vm);

		return View("SuccessRegister", vm);
	}

	#endregion Register
}
