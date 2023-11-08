using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("Add")]
        public IActionResult AddBook(AddBookModel model, string email, int userId)
        {
            try
            {
                var result = bookBusiness.AddBook(model, email, userId);
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
