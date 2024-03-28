using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class CustomerController(DataContext db) : Controller
{
    private readonly DataContext _dataContext = db;

    // public IActionResult Customers() => View(_dataContext.Discounts.Where(d => d.EndTime > DateTime.Today).OrderBy(d => d.EndTime));

    public IActionResult Register() => View(new Customer());
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(Customer model)
    {
        if (ModelState.IsValid)
        {
            if (_dataContext.Customers.Any(b => b.CompanyName == model.CompanyName))
            {
                ModelState.AddModelError("", "Name must be unique");
            }
            else
            {
                _dataContext.AddCustomer(model);
                return RedirectToAction("Customers");
            }
        }
        return View();
    }
    
    public IActionResult Customers() => View(_dataContext.Customers.OrderBy(c => c.CompanyName));
    // public IActionResult Index(int id) => View(_dataContext.Customers.First(c => c.CustomerId == id));
    public IActionResult Index(int id) => View(_dataContext.Customers.Where(c => c.CustomerId == id));

}
