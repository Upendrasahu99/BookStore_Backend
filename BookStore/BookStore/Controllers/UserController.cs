using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness adminBusiness;

        public UserController(IUserBusiness adminBusiness)
        {
            this.adminBusiness = adminBusiness;
        }

        [HttpPost("Register")]

        public IActionResult UserRegister(AdminUserRegisterModel mode)
        {
            try
            {
                var result = adminBusiness.RegisterUser(mode);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration successful", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Registration unsuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
