using Microsoft.AspNetCore.Mvc;

namespace DotNetGroupTalk.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return View();
        }    
    }
}