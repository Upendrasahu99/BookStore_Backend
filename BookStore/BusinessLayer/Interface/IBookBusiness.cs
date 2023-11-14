using CommonLayer.Model;
using CommonLayer.ReturnModel;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// This interface is provide the functionality required to work in our application
    /// </summary>
    public interface IBookBusiness
    {
        /// <summary>
        /// For adding book.
        /// </summary>
        /// <param name="model">For providing the book data</param>
        /// <returns>It return the book detail we added in database</returns>
        public BookDetailReturnModel AddBook(AddBookModel model);

        /// <summary>
        /// abstract method for get the book detail
        /// </summary>
        /// <param name="BookId">For particular book</param>
        /// <returns>return the particular book data</returns>
        public BookDetailReturnModel GetBook(int BookId);

        /// <summary>
        /// For update the book data.
        /// </summary>
        /// <param name="BookId">For particular book</param>
        /// <param name="model">For give the book data we want to update</param>
        /// <returns>return the book data updated book data</returns>
        public BookDetailReturnModel UpdateBook(int BookId, AddBookModel model);

        /// <summary>
        /// For delete the book
        /// </summary>
        /// <param name="bookId">for access particular book</param>
        /// <returns>return the deleted book data</returns>
        public BookDetailReturnModel DeleteBook(int bookId);

        /// <summary>
        /// For get all book 
        /// </summary>
        /// <returns>return the all book data</returns>
        public List<BookDetailReturnModel> GetAllBook();
    }
}
