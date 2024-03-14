using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ProductController(DataContext db) : Controller
{
    // this controller depends on the DataContext
    private readonly DataContext _dataContext = db;

    public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));

    public IActionResult Index(int id) => View(_dataContext.Products.Where(p => !p.Discontinued && p.CategoryId == id).OrderBy(p => p.ProductName));

}
