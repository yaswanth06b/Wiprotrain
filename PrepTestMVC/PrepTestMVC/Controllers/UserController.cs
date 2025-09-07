using Microsoft.AspNetCore.Mvc;

namespace PrepTestMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            ViewBag.Message = "welcome, user! here is your profile information.";
            return View();
        }
    }
}
