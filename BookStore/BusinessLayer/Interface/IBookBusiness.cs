using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IBookBusiness
    {
        public Book AddBook(AddBookModel model, string role, string email, int userId);
        public Book GetBook(int BookId);
    }
}
