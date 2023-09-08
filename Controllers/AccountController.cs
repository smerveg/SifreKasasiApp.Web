using Microsoft.AspNetCore.Mvc;

namespace SifreKasasiApp.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewBag.ID = id;
            return View();
        }
    }
}
