
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BestShop.Web.Extensions;

public class LoginService
{
	#region Constructor
	private readonly IHttpContextAccessor _httpContextAccessor;
	public LoginService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}
	#endregion Constructor

	#region Cookie Login
	public async Task LoginUserByCookie(User user, bool rememberMe)
	{
		var claims = new List<Claim>() {
				new Claim(ClaimTypes.Name,user.UserName),
				new Claim(ClaimTypes.Email, value: user.Email?? string.Empty),
				new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
				new Claim("AvatarPath",user.Avatar)

			};

		var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		var principal = new ClaimsPrincipal(identity);
		var properties = new AuthenticationProperties()
		{
			IsPersistent = rememberMe
		};
		if (_httpContextAccessor.HttpContext != null)
			await _httpContextAccessor.HttpContext.SignInAsync(principal, properties);
	}


	public async Task LogoutUserByCookie()
	{
		if (_httpContextAccessor.HttpContext == null)
			return;
		await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
	}
	#endregion Cookie Login

}
