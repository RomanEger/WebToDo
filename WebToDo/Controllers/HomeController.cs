using Microsoft.AspNetCore.Mvc;

namespace WebToDo.Controllers
{
    
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
