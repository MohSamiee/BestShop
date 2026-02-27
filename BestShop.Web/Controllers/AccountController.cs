using BestShop.Web.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BestShop.Web.Controllers;
public class AccountController : Controller
{

	#region Constructor
	private readonly IAccountService _accountService;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public AccountController(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
	{
		_accountService = accountService;
		_httpContextAccessor = httpContextAccessor;
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

	#region Activation
	[HttpGet("VerifyEmail/{activationCode}")]
	public async Task<IActionResult> VerifyEmail(string activationCode)
	{
		var result = await _accountService.ActivateAccount(activationCode);

		return View(result);
	}
	#endregion Activation

	#region Login
	[HttpGet("Login")]
	public async Task<IActionResult> Login(string? ReturnUrl)
	{
		ViewBag.ReturnUrl = ReturnUrl;
		return View();
	}

	[HttpPost("Login")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(LoginViewModel vm)
	{
		if (!ModelState.IsValid)
			return View(vm);

		var res = await _accountService.VerifyLogin(vm);
		if (!res.IsSuccess)
			if (res.ModelStateErrors != null && res.ModelStateErrors.Any())
			{
				foreach (var error in res.ModelStateErrors)
				{
					ModelState.AddModelError(error.ModelStateField, error.ModelStateErrorMessage);
				}
			}
		await new LoginService(_httpContextAccessor).LoginUserByCookie(res.Data!, vm.RememberMe);

		return Redirect(vm.ReturnUrl ?? "/");
	}
	#endregion Login

	#region Logout
	[HttpGet("/Logout")]
	public async Task<IActionResult> Logout()
	{
		await new LoginService(_httpContextAccessor).LogoutUserByCookie();
		return Redirect("/");
	}
	#endregion Logout
}
