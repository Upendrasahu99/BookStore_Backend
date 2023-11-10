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

        [Authorize]
        [HttpPost("PlaceOrder/{bookId}/{addressId}")]
        public IActionResult PlaceOrder(OrderBookModel orderBookModel, int bookId, int addressId)
        {
            try
            {
                int userId = int.Parse(User.FindFirst("UserId").Value);

                var result = orderBusiness.PlaceOrder(orderBookModel, userId, bookId, addressId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Order placed", result = result });
                }
                return BadRequest(new { success = false, message = "Order not placed", result = result });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet("GetOrder/{orderId}")]
        public IActionResult GetOrderDetail(int orderId)
        {
            try
            {
                var result = orderBusiness.OrderDetail(orderId);
                if (result != null)
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

        [Authorize(Roles = "User")]
        [HttpGet("GetAllOrder")]
        public IActionResult GetAllOrder()
        {
            try
            {
                int userId = int.Parse(User.FindFirst("UserId").Value);
                var result = orderBusiness.GetAllOrder(userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "All Orders", result = result });
                }
                return BadRequest(new { success = false, message = "There is not orders placed in past" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = "User")]
        [HttpDelete("CancelOrder/{orderId}")]
        public IActionResult CancelOrder(int orderId)
        {
            try
            {
                int userId = int.Parse(User.FindFirst("UserId").Value);
                var result = orderBusiness.CancelOrder(orderId, userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Order cancel successfully", result = result });
                }
                return BadRequest(new { success = false, message = "Order not canceled" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
