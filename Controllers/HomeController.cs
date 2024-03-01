using Microsoft.AspNetCore.Mvc;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        // public string Index() => "This is Home";
        public ActionResult Index() => View();
    }
}