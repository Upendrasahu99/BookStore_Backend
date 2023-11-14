using CommonLayer.Model;
using CommonLayer.ReturnModel;
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
        public BookDetailReturnModel AddBook(AddBookModel model)
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
                book.Stock = model.Stock;
                context.Book.Add(book);
                context.SaveChanges();
                return (book != null ? GetBook(book.BookId) : null);
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
        public BookDetailReturnModel GetBook(int BookId)
        {
            try
            {
                Book book = context.Book.SingleOrDefault(u => u.BookId == BookId);
                if(book != null)
                {
                    BookDetailReturnModel bookDetailReturnModel = new BookDetailReturnModel();
                    bookDetailReturnModel.BookId = book.BookId;
                    bookDetailReturnModel.Title = book.Title;
                    bookDetailReturnModel.BookCode = book.Code;
                    bookDetailReturnModel.Author = book.Author;
                    bookDetailReturnModel.Language = book.Language;
                    bookDetailReturnModel.Publisher = book.Publisher;
                    bookDetailReturnModel.Price = book.Price;
                    bookDetailReturnModel.PageCount = book.PageCount;
                    bookDetailReturnModel.Image = book.Image;
                    bookDetailReturnModel.Stock = book.Stock;
                    return bookDetailReturnModel;
                }
                return null;
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
        public BookDetailReturnModel UpdateBook(int BookId, AddBookModel model)
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
                    book.Stock = model.Stock;
                    context.SaveChanges();
                    return GetBook(book.BookId);
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
        public BookDetailReturnModel DeleteBook(int bookId)
        {
            try
            {
                Book book = context.Book.SingleOrDefault(u => u.BookId == bookId);
                if(book != null)
                {
                    context.Book.Remove(book);
                    context.SaveChanges();
                    return GetBook(book.BookId);
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
        public List<BookDetailReturnModel> GetAllBook()
        {
            try
            {
                List<BookDetailReturnModel> bookList = new List<BookDetailReturnModel>();
                var allBook = context.Book.ToList(); //FIrst covert in list not direct put in foreach beause it give error
                foreach(var model in allBook)
                {
                    bookList.Add(GetBook(model.BookId));
                }
                
                if(context.Book.Count() > 0)
                {
                    return bookList;
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
