using BestShop.Common.ViewModels.Options;

namespace BestShop.Web.Extensions
{
	public static class RegisterOptions
	{
		public static void RegisterOptionsInjection(this WebApplicationBuilder builder)
		{
			builder.Services.Configure<PasswordPolicyOptions>(builder.Configuration.GetSection("PasswordPolicy"));
		}
	}
}