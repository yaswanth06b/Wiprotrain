using Microsoft.AspNetCore.Mvc;

namespace PrepTestMVC.Controllers
{
    public class AdminController1 : Controller
    {
        public IActionResult Dashboard()
        {
            ViewBag.Message = "welcome, admin! you have access to the admin dashboard.";
            return View();
        }
    }
}
