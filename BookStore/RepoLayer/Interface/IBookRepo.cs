using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    /// <summary>
    /// Interface provide functionality to work with book
    /// </summary>
    public interface IBookRepo
    {
        /// <summary>
        /// For adding book
        /// </summary>
        /// <param name="model">Provide data</param>
        /// <returns>return book data</returns>
        public Book AddBook(AddBookModel model);
        /// <summary>
        /// For get book detail
        /// </summary>
        /// <param name="BookId">For accessing particular book</param>
        /// <returns></returns>
        public Book GetBook(int BookId);
        /// <summary>
        /// For update the book data
        /// </summary>
        /// <param name="BookId">For accessing the particular book</param>
        /// <param name="model">For giving book data we want to update</param>
        /// <returns>return the updated book data</returns>
        public Book UpdateBook(int BookId, AddBookModel model);
        /// <summary>
        /// For delete the book
        /// </summary>
        /// <param name="bookId">For accessing the particualr book</param>
        /// <returns>return the deleted book data</returns>
        public Book DeleteBook(int bookId);
        /// <summary>
        /// For get all the book
        /// </summary>
        /// <returns>All the book data</returns>
        public List<Book> GetAllBook();
    }
}
