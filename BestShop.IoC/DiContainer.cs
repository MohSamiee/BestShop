using BestShop.Data.Repositories.Users;
using BestShop.Domain.Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BestShop.IoC;
public static class DiContainer
{
	public static void RegisterServices(this IServiceCollection services)
	{

	}

	public static void RegisterRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();

	}
}
