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
        private readonly IUserBusiness userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpPost("Register")]

        public IActionResult UserRegister(AdminUserRegisterModel mode)
        {
            try
            {
                var result = userBusiness.RegisterUser(mode);
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

        [HttpPost("Login")]
        public IActionResult UserLogin(UserLoginModel model)
        {
            try
            {
                var result = userBusiness.UserLogin(model);
                if(result != null)
                {
                    return this.Ok(new { success = true, message = "Login successful", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Login Unsuccessful"});
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
