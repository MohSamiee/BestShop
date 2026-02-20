using BestShop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BestShop.Web.Extensions
{
	public static class RegisterDatabase
	{
		public static void ConfigDatabase(this WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<BestShopContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("BestShopConnectionString"));
			});
		}
	}
}
