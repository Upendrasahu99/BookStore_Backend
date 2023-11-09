using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    /// <summary>
    /// Implementing IBookRepo method
    /// </summary>
    public class BookRepo : IBookRepo
    {
        /// <summary>
        /// For accessing the Context class and functionality for work with database
        /// </summary>
        private readonly BookStoreContext context;
        public BookRepo(BookStoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// For adding book data in database using context
        /// </summary>
        /// <param name="model">For adding book data</param>
        /// <returns>Book data which we added in database</returns>
        public Book AddBook(AddBookModel model)
        {
            try
            {
                Book book = new Book();
                book.Title = model.Title;
                book.Code = model.BookCode;
                book.Author = model.Author;
                book.Language = model.Language;
                book.Publisher = model.Publisher;
                book.Price = model.Price;
                book.PageCount = model.PageCount;
                book.Image = model.Image;
                book.Quantity = model.Quantity;
                context.Book.Add(book);
                context.SaveChanges();

                return (book != null ? book : null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// For get the book data form database
        /// </summary>
        /// <param name="BookId">Accessing particular book</param>
        /// <returns>Book data from database</returns>
        public Book GetBook(int BookId)
        {
            try
            {
                Book book = context.Book.SingleOrDefault(u => u.BookId == BookId);
                return book != null ? book : null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// For update the book data in database
        /// </summary>
        /// <param name="BookId">Accessing particular book</param>
        /// <param name="model">For enter the data</param>
        /// <returns>Updated book data from database</returns>
        public Book UpdateBook(int BookId, AddBookModel model)
        {
            try
            {
                Book book = context.Book.SingleOrDefault(u => u.BookId == BookId);
                if(book != null)
                {
                    book.Title = model.Title;
                    book.Code = model.BookCode;
                    book.Author = model.Author;
                    book.Language = model.Language;
                    book.Publisher = model.Publisher;
                    book.Price = model.Price;
                    book.PageCount = model.PageCount;
                    book.Image = model.Image;
                    book.Quantity = model.Quantity;
                    context.SaveChanges();
                    return book;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// For delete the book from database.
        /// </summary>
        /// <param name="bookId">accessing particular book</param>
        /// <returns>Deleted book data from database</returns>
        public Book DeleteBook(int bookId)
        {
            try
            {
                Book book = context.Book.SingleOrDefault(u => u.BookId == bookId);
                if(book != null)
                {
                    context.Book.Remove(book);
                    context.SaveChanges();
                    return book;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// For get all book data from database
        /// </summary>
        /// <returns>All book data from database</returns>
        public List<Book> GetAllBook()
        {
            try
            {
                if(context.Book.Count() > 0)
                {
                    return context.Book.ToList();
                } 
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
