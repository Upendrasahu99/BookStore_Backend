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
    public class OrderRepo : IOrderRepo
    {
		private readonly BookStoreContext context;

		public OrderRepo(BookStoreContext context)
		{
			this.context = context;
		}
		public OrderRepo() { }
		public OrderData PlaceOrder(OrderBookModel model, int userId, int bookId, int AddressId)
		{
			try
			{
				Book book = context.Book.SingleOrDefault(u => u.BookId == bookId);
				if (book == null)
				{
					return null;
				}
				OrderData orderData = new OrderData();
				orderData.Quantity = model.Quantity;
				orderData.Amount = book.Price * model.Quantity;
				orderData.DateTime = DateTime.Now;
				orderData.UserId = userId;
				orderData.BookId = bookId;
				orderData.AddressId = AddressId;
				book.Stock = book.Stock - model.Quantity;
				context.Add(orderData);
				context.SaveChanges();
				if(orderData != null)
				{
					return orderData;
				}
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public OrderDetailReturn OrderDetail(int orderId)
		{
			try
			{
				OrderData order = context.OrderData.SingleOrDefault(u => u.OrderId == orderId);
				if (order != null && order.UserId != null && order.AddressId != null && order.BookId != null)
				{
					Users user = context.Users.SingleOrDefault(u => u.UserId == order.UserId);
					Book book = context.Book.SingleOrDefault(u => u.BookId == order.BookId);
					Address address = context.Address.SingleOrDefault(u => u.AddressId == order.AddressId);

					OrderDetailReturn orderDetail = new OrderDetailReturn();
					orderDetail.FirstName = user.FirstName;
					orderDetail.LastName = user.LastName;
					orderDetail.MobileNum = user.MobileNum;
					orderDetail.Email = user.Email;
					orderDetail.Title = book.Title;
					orderDetail.BookCode = book.Code;
					orderDetail.Author = book.Author;
					orderDetail.Language = book.Language;
					orderDetail.Publisher = book.Publisher;
					orderDetail.Price = book.Price;
					orderDetail.Image = book.Image;
					orderDetail.Quantity = order.Quantity;
					orderDetail.Amount = order.Amount;
					orderDetail.DateTime = order.DateTime;
					orderDetail.City = address.City;
					orderDetail.PinCode = address.PinCode;
					orderDetail.State = address.State;
					orderDetail.Country = address.Country;
					return orderDetail;
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
