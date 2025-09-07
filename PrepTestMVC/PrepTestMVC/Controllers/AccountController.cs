using Microsoft.AspNetCore.Mvc;
using PrepTestMVC.ViewModel;


public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // fake check – replace with DB check
        if (model.username == "admin" && model.password == "admin123")
        {
            return RedirectToAction("Dashboard", "Admin");
        }

        ModelState.AddModelError("", "Invalid login");
        return View(model);
    }
}
