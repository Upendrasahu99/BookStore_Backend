using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("RegisterUser")]

        public IActionResult UserRegister(AdminUserRegisterModel model)
        {
            try
            {
                string role = "User";
                var result = userBusiness.RegisterUser(model, role);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration successful", data = result });
                }
                    return this.BadRequest(new { success = false, message = "Registration unsuccessful" });
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
                    return Ok(new { success = true, message = "Login successful", data = result });
                }
                    return BadRequest(new { success = false, message = "Login Unsuccessful"});
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost("AdminReg")]
        public IActionResult AdminRegister(AdminUserRegisterModel model)
        {
            try
            {
                int adminId = int.Parse(User.FindFirst("UserId").Value);
                if(adminId != 2)
                {
                    return BadRequest(new { message = "You are not authorize for this" });
                }
                string role = "Admin";
                var result = userBusiness.RegisterUser(model, role);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Admin registration successful", result = result });
                }
                return BadRequest(new { success = false, message = "Admin registration unsuccessful" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("Forgot")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var result = userBusiness.ForgotPassword(email);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Token send", result = result });
                }
                return BadRequest(new { success = false, message = "Email not found" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
