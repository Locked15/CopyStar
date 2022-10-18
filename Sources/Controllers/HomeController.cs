using Microsoft.AspNetCore.Mvc;

namespace CopyStar.Sources.Controllers
{
    /// <summary>
    /// Base controller of the application.
    /// Automatically redirects user to "Welcome" page.
    /// </summary>
    public class HomeController : BaseController
    {
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult Information()
        {
            return View();
        }
    }
}
