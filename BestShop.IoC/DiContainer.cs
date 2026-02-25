using Microsoft.Extensions.DependencyInjection;

namespace BestShop.IoC;
public static class DiContainer
{
	public static void RegisterServices(this IServiceCollection services)
	{
		services.AddScoped<IAccountService, AccountService>();

	}

	public static void RegisterRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();

	}
}
