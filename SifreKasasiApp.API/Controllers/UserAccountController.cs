using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SifreKasasiApp.Business.Abstract;
using SifreKasasiApp.EntityLayer.DTOs;

namespace SifreKasasiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        [HttpGet]
        public IEnumerable<UserAccountDTO> Get(int userId)
        {

            var accountList = userAccountService.GetAllByUserId(userId);
            return accountList;


        }

        [HttpGet("GetAccount")]
        public UserAccountDTO GetAccount(int accountId)
        {

            var account = userAccountService.GetById(accountId);
            return account;


        }

        [HttpPost]
        public IActionResult Add(UserAccountDTO entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userAccountService.Add(entity);
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

        [HttpPost("UpdateAccount")]
        public IActionResult Update(UserAccountDTO entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userAccountService.Update(entity);
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

        [HttpPost("DeleteAccount")]
        public void Delete(int accountId)
        {
            try
            {
                userAccountService.Delete(accountId);

            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
