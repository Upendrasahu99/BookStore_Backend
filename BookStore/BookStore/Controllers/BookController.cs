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
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness bookBusiness;
        public BookController(IBookBusiness bookBusiness)
        {
            this.bookBusiness = bookBusiness;
        }

        [Authorize]
        [HttpPost("Add")]
        public IActionResult AddBook(AddBookModel model)
        {
            try
            {
                string role = User.FindFirst("Role").Value;
                if(role != "Admin")
                {
                    return BadRequest(new { success = false, message = "You are not eligible" });
                }
                string email = User.FindFirst(ClaimTypes.Email).Value;
                int userId = int.Parse(User.FindFirst("UserId").Value);
                var result = bookBusiness.AddBook(model, role, email, userId);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Book added successfully", result = result });
                }
                return BadRequest(new { success = false, message = "Book not added" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("Get")]
        public IActionResult GetBook(string bookCode)
        {
            try
            {
                var result = bookBusiness.GetBook(bookCode);
                if( result != null )
                {
                    return Ok(new { success = true, message = "Book found", result = result});
                }
                return BadRequest(new { success = false, message = "Book not found" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
