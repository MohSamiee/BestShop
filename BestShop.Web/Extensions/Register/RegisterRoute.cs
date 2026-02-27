namespace BestShop.Web.Extensions.Register;

public static class RegisterRoute
{
	public static void RegisterRouting(this WebApplication app)
	{
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllerRoute(
			  name: "areas",
			  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
			);
			endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();
		});
	}
}
