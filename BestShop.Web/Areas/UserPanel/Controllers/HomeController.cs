using Microsoft.AspNetCore.Mvc;

namespace BestShop.Web.Areas.UserPanel.Controllers;
public class HomeController : UserPanelBaseContgroller
{
	public IActionResult Index()
	{
		return Content("User Panel");
	}
}
