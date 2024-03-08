using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ProductController(DataContext db) : Controller
{
    // this controller depends on the DataContext
    private readonly DataContext _dataContext = db;


    // public IActionResult Category() => View(_dataContext.Categories.Include(c => c.Products).OrderBy(c => c.CategoryName));
    public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));

    public IActionResult Product(int id) => View(_dataContext.Products.OrderBy(p => p.ProductName));

//   public IActionResult BlogDetail(int id) => View(new PostViewModel
//   {
//     blog = _dataContext.Blogs.FirstOrDefault(b => b.BlogId == id),
//     Posts = _dataContext.Posts.Where(p => p.BlogId == id)
//   });
    // public IActionResult Index(int id) => View(_dataContext.Products.Where(p => p.CategoryId == id && !p.Discontinued));


}
