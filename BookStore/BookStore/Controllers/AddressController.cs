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
        private readonly ILogger logger;
        public AddressController(IAddressBusiness addressBusiness, ILogger logger)
        {
            this.addressBusiness = addressBusiness;
            this.logger = logger;
        }

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
    }
}
