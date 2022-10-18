using Microsoft.AspNetCore.Mvc;

namespace CopyStar.Sources.Controllers
{
    [Controller]
    public class HomeController : BaseController
    {
        public IActionResult Welcome()
        {
            return View();
        }
    }
}
