using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestShop.Web.Areas.UserPanel.Controllers;
[Area("UserPanel")]
[Authorize]
public class UserPanelBaseContgroller : Controller
{

}
