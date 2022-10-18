using Microsoft.AspNetCore.Mvc;

namespace CopyStar.Sources.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Basket()
        {
            return View();
        }
    }
}
