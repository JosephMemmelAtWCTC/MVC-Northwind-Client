using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ProductController(DataContext db) : Controller
{
    // this controller depends on the DataContext
    private readonly DataContext _dataContext = db;


    // public IActionResult Category() => View(_dataContext.Categories.Include(c => c.Products).OrderBy(c => c.CategoryName));
    public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));

    // public IActionResult Products(int id) => View(_dataContext.Products.OrderBy(p => p.ProductName));

    public IActionResult Index(int id) => View(_dataContext.Products.OrderBy(b => b.CategoryId == id));

    // public IActionResult Index(int id) => View(new PostViewModel
    // {
    //     category = _dataContext.Categories.FirstOrDefault(b => b.CategoryId == id),
    //     products = _dataContext.Products.Where(p => p.CategoryId == id)
    // });

}
