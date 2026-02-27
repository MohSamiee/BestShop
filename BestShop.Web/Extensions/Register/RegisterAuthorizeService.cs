using Microsoft.AspNetCore.Authentication.Cookies;

namespace BestShop.Web.Extensions.Register;

public static class RegisterAuthorizeService
{
	public static void RegisterCookieAuthorize(this WebApplicationBuilder builder)
	{
		builder.Services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

	}).AddCookie(options =>
	{
		options.LoginPath = "/Login";
		options.LogoutPath = "/Logout";
		options.ExpireTimeSpan = TimeSpan.FromDays(30);
	});
	}
}
