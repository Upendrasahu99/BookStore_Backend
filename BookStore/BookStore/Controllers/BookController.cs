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
        /// <summary>
        /// Action method for add book by admin only.
        /// </summary>
        /// <param name="model">Model is user for add book detail</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public IActionResult AddBook(AddBookModel model)
        {
            try
            {
                var result = bookBusiness.AddBook(model);
                if (result != null)
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

        /// <summary>
        /// Action method is used for get book detail.
        /// </summary>
        /// <param name="bookId">Using bookId we get particular book.</param>
        /// <returns></returns>
        [HttpGet("Get/{bookId}")]
        public IActionResult GetBook(int bookId)
        {
            try
            {
                var result = bookBusiness.GetBook(bookId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Book found", result = result });
                }
                return BadRequest(new { success = false, message = "Book not found" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Action method is used for update the particular book detail by admin only.
        /// </summary>
        /// <param name="bookId">bookId is used to select the particular book</param>
        /// <param name="model">model used to add the data of book</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{bookId}")]
        public IActionResult UpdateBook(int bookId, AddBookModel model)
        {
            try
            {
                var result = bookBusiness.UpdateBook(bookId, model);
                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Book data updated", result = result });
                }
                return BadRequest(new { success = false, message = "Book not updated" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Action method is used for delete the particular book.
        /// </summary>
        /// <param name="bookId">bookId is used for chose the particular book</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{bookId}")]
        public IActionResult Delete(int bookId)
        {
            try
            {
                var result = bookBusiness.DeleteBook(bookId);
                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Book deleted", result = result });
                }
                return BadRequest(new { success = false, message = "Book not deleted" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Action method is used to access the all the book.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = bookBusiness.GetAllBook();
                if (result != null)
                {
                    return Ok(new { sucess = true, message = "All book dat", result = result });
                }
                return BadRequest(new { success = false, message = "There is not a single book" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
