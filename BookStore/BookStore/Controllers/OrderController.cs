using BusinessLayer.Interface;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness orderBusiness;
        private readonly ILogger<OrderController> logger;
        public OrderController(IOrderBusiness orderBusiness, ILogger<OrderController> logger)
        {
            this.orderBusiness = orderBusiness;
            this.logger = logger;
        }

        /// <summary>
        /// For place new Order where user only able to place order
        /// </summary>
        /// <param name="orderBookModel">For Enter the order detail</param>
        /// <param name="bookId">For chose book</param>
        /// <param name="addressId">For Chose one address of user</param>
        /// <returns>Http status with message and result if success is true</returns>
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
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }


        /// <summary>
        /// For Order Detail
        /// </summary>
        /// <param name="orderId">For chose one order</param>
        /// <returns>Http status with message and result if success is true</returns>
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
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// For get all order detail
        /// </summary>
        /// <returns>Http status with message and result if result is not null</returns>
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
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// For cancel order
        /// </summary>
        /// <param name="orderId">For select one order</param>
        /// <returns>Http status with message and result if result is not null</returns>
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
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
