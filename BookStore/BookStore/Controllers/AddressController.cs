using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBusiness addressBusiness;
        public AddressController(IAddressBusiness addressBusiness)
        {
            this.addressBusiness = addressBusiness;
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
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
