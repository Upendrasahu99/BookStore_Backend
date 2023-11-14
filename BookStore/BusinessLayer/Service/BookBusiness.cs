using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.ReturnModel;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
	/// <summary>
	/// This methos is Implemented the IBookBusiness method
	/// </summary>
    public class BookBusiness : IBookBusiness
    {
		/// <summary>
		/// For provide the BookRepo object for accessing the functionality
		/// </summary>
		private readonly IBookRepo bookRepo;
		/// <summary>
		/// Constructor is provide the dependency injection for bookRepo through startup class.
		/// </summary>
		/// <param name="bookRepo">object for providing dependency</param>
		public BookBusiness(IBookRepo bookRepo)
		{
			this.bookRepo = bookRepo;
		}
		/// <summary>
		/// Implemented AddBook method
		/// </summary>
		/// <param name="model">Provide the data enter in book table</param>
		/// <returns>return book data which we enter in book table</returns>
        public BookDetailReturnModel AddBook(AddBookModel model)
        {
			try
			{
				return bookRepo.AddBook(model);
			}
			catch (Exception)
			{

				throw;
			}
        }
		/// <summary>
		/// Implemented get book data
		/// </summary>
		/// <param name="BookId">For accessing particular book</param>
		/// <returns>return the data of book from datatbase</returns>
        public BookDetailReturnModel GetBook(int BookId)
		{
			try
			{
				return bookRepo.GetBook(BookId);
			}
			catch (Exception)
			{

				throw;
			}
		}
		/// <summary>
		/// For update the book detail
		/// </summary>
		/// <param name="BookId">For accessing the particular book</param>
		/// <param name="model">For provide the data</param>
		/// <returns>return the updated book detail</returns>

        public BookDetailReturnModel UpdateBook(int BookId, AddBookModel model)
		{
			try
			{
				return bookRepo.UpdateBook(BookId, model);
			}
			catch (Exception)
			{

				throw;
			}
		}
		/// <summary>
		/// Implemented delete book
		/// </summary>
		/// <param name="bookId">For accessing the particular book</param>
		/// <returns>return the deleted book data</returns>
        public BookDetailReturnModel DeleteBook(int bookId)
		{
			try
			{
				return bookRepo.DeleteBook(bookId);
			}
			catch (Exception)
			{

				throw;
			}
		}
		/// <summary>
		/// Implement all book detail
		/// </summary>
		/// <returns>return all book data</returns>
        public List<BookDetailReturnModel> GetAllBook()
		{
			try
			{
				return bookRepo.GetAllBook();
			}
			catch (Exception)
			{

				throw;
			}
		}
    }
}
