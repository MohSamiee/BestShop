using Microsoft.AspNetCore.Mvc;

namespace BestShop.Web.Areas.AdminPanel.Controllers;
public class HomeController : AdminPanelBaseContgroller
{
	public IActionResult Index()
	{
		return Content("User Panel");
	}
}
