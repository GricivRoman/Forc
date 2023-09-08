using Microsoft.AspNetCore.Mvc;

namespace ForcWebApi.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
