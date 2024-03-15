using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Controllers
{
    public class HomeController(DataContext db) : Controller
    {
        // public string Index() => "This is Home";
        // public ActionResult Index() => View();
        
        // this controller depends on the DataContext
        private readonly DataContext _dataContext = db;
        // public ActionResult Index() => View(_dataContext.Discounts);
        // public ActionResult Index() => View(_dataContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now).Take(3));
        public ActionResult Index() => View(_dataContext.Discounts.Include("Product").Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now).Take(3));
    }
}