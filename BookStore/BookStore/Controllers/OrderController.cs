using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness orderBusiness;
        public OrderController(IOrderBusiness orderBusiness)
        {
            this.orderBusiness = orderBusiness;
        }

        [Authorize (Roles = "User")]
        [HttpPost("PlaceOrder/{bookId}/{addressId}")]
        public IActionResult PlaceOrder(OrderBookModel orderBookModel, int bookId, int addressId)
        {
            try
            {
                int userId = int.Parse(User.FindFirst("UserId").Value);

                var result = orderBusiness.PlaceOrder(orderBookModel, userId, bookId, addressId);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Order placed", result = result });
                }
                return BadRequest(new { success = false, message = "Order not placed", result = result});
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize (Roles = "User")]
        [HttpGet("GetOrder/{orderId}")]
        public IActionResult GetOrderDetail(int orderId)
        {
            try
            {
                var result = orderBusiness.OrderDetail(orderId);
                if(result != null )
                {
                    return Ok(new { success = true, message = "Order Detail", result = result });
                }
                return BadRequest(new { success = false, message = "Not able to find any order" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
