using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SifreKasasiApp.Business.Abstract;
using SifreKasasiApp.EntityLayer.DTOs;

namespace SifreKasasiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginDTO entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = userService.LoginControl(entity);

                    if (result != 0)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
