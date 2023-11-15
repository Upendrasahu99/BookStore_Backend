using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBusiness addressBusiness;
        private readonly ILogger<AddressController> logger;
        public AddressController(IAddressBusiness addressBusiness, ILogger<AddressController> logger)
        {
            this.addressBusiness = addressBusiness;
            this.logger = logger;
        }

        /// <summary>
        /// For add address of user and admin
        /// </summary>
        /// <param name="addressModel">For enter the address detail</param>
        /// <returns>Http status with message and result if result is not null</returns>
        [Authorize]
        [HttpPost("AddAddress")]
        public IActionResult AddAddress(AddAddressModel addressModel)
        {
            try
            {
                int userId = int.Parse(User.FindFirst("UserId").Value);
                var result = addressBusiness.AddAddress(addressModel, userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address added successfully", result = result });
                }
                return BadRequest(new { success = false, message = "Address not added" });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Action method for get the particular address of user
        /// </summary>
        /// <param name="addressId">for access particular address from table</param>
        /// <returns>status code and if result not null get result data</returns>
        [Authorize]
        [HttpGet("Get/{addressId}")]
        public IActionResult GetAddress(int addressId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var result = addressBusiness.GetAddress(userId, addressId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address Detail", result = result });
                }
                return BadRequest(new { success = false, message = "Address not found" });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Action method for get all address of particular user
        /// </summary>
        /// <returns>Status code and if result not null get result data</returns>
        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAllAddress()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var result = addressBusiness.GetAllAddress(userId);
                if(result != null)
                {
                    return Ok(new { success = true, message = "All address", result = result });
                }
                return BadRequest(new { success = false, message = "Address not found" });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
