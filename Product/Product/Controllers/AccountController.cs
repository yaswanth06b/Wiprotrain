using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

public class AccountController : Controller
{
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = UserStore.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        if (user == null)
        {
            ViewBag.Error = "Invalid credentials!";
            return View();
        }

        HttpContext.Session.SetString("Username", user.UserName);
        HttpContext.Session.SetString("Role", user.Role);

        return RedirectToAction("ProductList", "Product");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
