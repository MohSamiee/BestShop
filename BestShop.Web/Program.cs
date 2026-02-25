using BestShop.IoC;
using BestShop.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Register Database
builder.ConfigDatabase();
#endregion Register Database

#region Register Services

builder.Services.RegisterRepositories();

builder.Services.RegisterServices();

#endregion Register Services

#region Register Options
builder.RegisterOptionsInjection();
#endregion Register Options
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
	endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();
});

app.Run();
