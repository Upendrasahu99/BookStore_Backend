using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBusiness : IBookBusiness
    {
		private readonly IBookRepo bookRepo;
		public BookBusiness(IBookRepo bookRepo)
		{
			this.bookRepo = bookRepo;
		}
        public Book AddBook(AddBookModel model, string role, string email, int userId)
        {
			try
			{
				return bookRepo.AddBook(model, role, email, userId);
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
