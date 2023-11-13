using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;
        private readonly ILogger<UserController> logger;
        public UserController(IUserBusiness userBusiness, ILogger<UserController> logger)
        {
            this.userBusiness = userBusiness;
            this.logger = logger;
        }

       /// <summary>
       /// Action method is for user Registration where it calling userBusiness RegisterUser method
       /// </summary>
       /// <param name="model">Enter the data for user detail</param>
       /// <returns>Http status with message and result if success is true</returns>
        [HttpPost("RegisterUser")]
        public IActionResult UserRegister(AdminUserRegisterModel model)
        {
            try
            {
                string role = "User";
                var result = userBusiness.RegisterUser(model, role);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Registration successful", data = result });
                }
                    return BadRequest(new { success = false, message = "Registration unsuccessful" });
            }
            catch (Exception ex)
            {
                logger.LogError(ex,ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Action method is for user Login where it calling UserBusiness UerLogin method
        /// </summary>
        /// <param name="model">Enter user email and password</param>
        /// <returns>Http status with message and result if success is true</returns>
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
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Action method is for user AdminRegistration  where it calling UserBusiness  RegisterUser method
        /// </summary>
        /// <param name="model">Enter admin data</param>
        /// <returns>Http status with message and result if success is true</returns>
        [Authorize ]
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
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// For Forgot password for user and admin both where it calling UserBusiness ForgotPassword method
        /// </summary>
        /// <param name="email">For send toke if email in our database</param>
        /// <returns>Http status with message and result if success is true</returns>
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
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// For Reset password where it calling UserBusiness ResetPassword method.
        /// </summary>
        /// <param name="newPassword">Enter new password</param>
        /// <param name="confirmPassword">For Confirmation of password</param>
        /// <returns>Http status with message and result if success is true</returns>
        [Authorize]
        [HttpPut("Reset")]
        public IActionResult ResetPassword(string newPassword, string confirmPassword)
        {
            try
            {
                string email = User.FindFirst(ClaimTypes.Email).Value;
                var result = userBusiness.ResetPassword(email, newPassword, confirmPassword);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Reset password successful", result = result });
                }
                return BadRequest(new { success = false, message = "Reset password unsuccessful"});
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
