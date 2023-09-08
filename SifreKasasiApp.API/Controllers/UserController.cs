using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SifreKasasiApp.Business.Abstract;

namespace SifreKasasiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
    }
}
