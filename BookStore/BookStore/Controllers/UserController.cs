﻿using BusinessLayer.Interface;
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
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RegisterUser")]
        public IActionResult UserRegister(AdminUserRegisterModel model)
        {
            try
            {
                int a = 0;
                int b = 1;
                int c = b / a;
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
