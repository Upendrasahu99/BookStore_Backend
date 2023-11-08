using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBusiness
    {
		private readonly IBookRepo bookRepo;
		public BookBusiness(IBookRepo bookRepo)
		{
			this.bookRepo = bookRepo;
		}
        public Book AddBook(AddBookModel model, string email, int userId)
        {
			try
			{
				return bookRepo.AddBook(model, email, userId);
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
				return bookRepo.GetBook(bookCode);
			}
			catch (Exception)
			{

				throw;
			}
		}
    }
}
