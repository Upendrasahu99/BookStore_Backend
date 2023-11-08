using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class BookRepo
    {
        private readonly BookStoreContext context;
        public BookRepo(BookStoreContext context)
        {
            this.context = context;
        }
        public Book AddBook(AddBookModel model, string email, int userId)
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
                Users user = context.Users.SingleOrDefault(u => u.Email == email && u.UserId == userId);
                return (user != null ? book : null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book GetBook(string bookCode)
        {
            try
            {
                Book book = context.Book.SingleOrDefault(u => u.Code == bookCode);
                return book != null ? book : null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
