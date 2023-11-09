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
    public class BookRepo : IBookRepo
    {
        private readonly BookStoreContext context;
        public BookRepo(BookStoreContext context)
        {
            this.context = context;
        }
        public Book AddBook(AddBookModel model, string role, string email, int userId)
        {
            try
            {
                Users admin = context.Users.SingleOrDefault(u => u.Email == email && u.UserId == userId);
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
                Users user = context.Users.SingleOrDefault(u => u.Email == email && u.UserId == userId);
                return (admin != null ? book : null);
            }
            catch (Exception)
            {
                throw;
            }
        }

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

    }
}
