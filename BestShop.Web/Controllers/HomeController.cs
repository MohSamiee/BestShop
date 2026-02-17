using Microsoft.AspNetCore.Mvc;

namespace BestShop.Web.Controllers;

public class HomeController : Controller
{
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult AboutUs()
	{
		return View();
	}


	public IActionResult ContactUs()
	{
		return View();
	}

}
