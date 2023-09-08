using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SifreKasasiApp.Business.Abstract;
using SifreKasasiApp.EntityLayer.DTOs;

namespace SifreKasasiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService userService;

        public RegisterController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Register(UserDTO entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.Add(entity);
                    return Ok();
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
