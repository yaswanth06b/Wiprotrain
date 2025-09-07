using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Models;

public class ProductController : Controller
{
    private string CurrentRole => HttpContext.Session.GetString("Role");
    private string CurrentUser => HttpContext.Session.GetString("Username");

    public IActionResult ProductList()
    {
        return View(ProductStore.Products);
    }

    public IActionResult Create()
    {
        if (CurrentRole != "Admin")
            return Unauthorized("Access Denied: Only Admin can create products.");
        return View();
    }

    [HttpPost]
    public IActionResult Create(ProductModel product)
    {
        if (CurrentRole != "Admin")
            return Unauthorized("Access Denied: Only Admin can create products.");

        product.Id = ProductStore.Products.Count + 1;
        ProductStore.Products.Add(product);
        TempData["Message"] = $"Product '{product.Name}' has been successfully created!";
        return RedirectToAction("ProductList");
    }

    public IActionResult Edit(int id)
    {
        var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        if (CurrentRole != "Admin" && CurrentRole != "Manager")
            return Unauthorized("Access Denied.");

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(ProductModel updated)
    {
        var product = ProductStore.Products.FirstOrDefault(p => p.Id == updated.Id);
        if (product == null) return NotFound();

        if (CurrentRole != "Admin" && CurrentRole != "Manager")
            return Unauthorized("Access Denied.");

        product.Name = updated.Name;
        product.Price = updated.Price;

        TempData["Message"] = $"Product '{product.Name}' has been successfully updated!";
        return RedirectToAction("ProductList");
    }

    public IActionResult Delete(int id)
    {
        if (CurrentRole != "Admin")
            return Unauthorized("Access Denied: Only Admin can delete products.");

        var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        ProductStore.Products.Remove(product);
        TempData["Message"] = $"Product '{product.Name}' has been successfully deleted!";
        return RedirectToAction("ProductList");
    }
}
