using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IBookRepo
    {
        public Book AddBook(AddBookModel model, string role, string email, int userId);
        public Book GetBook(string bookCode);
    }
}
