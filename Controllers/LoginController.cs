using Microsoft.AspNetCore.Mvc;

namespace SifreKasasiApp.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
