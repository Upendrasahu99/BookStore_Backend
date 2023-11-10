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
				int row = context.SaveChanges();
				if(row > 0)
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

					OrderDetailReturn orderDetailReturn = new OrderDetailReturn();
					orderDetailReturn.Title = book.Title;
					orderDetailReturn.BookCode = book.Code;
					orderDetailReturn.Price = book.Price;
					orderDetailReturn.Image = book.Image;
					orderDetailReturn.Quantity = order.Quantity;
					orderDetailReturn.Amount = order.Amount;
					orderDetailReturn.DateTime = order.DateTime;
					orderDetailReturn.FullAddress = address.FullAddress;
					orderDetailReturn.City = address.City;
					orderDetailReturn.PinCode = address.PinCode;
					orderDetailReturn.State = address.State;
					return orderDetailReturn;
				}
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public List<OrderDetailReturn> GetAllOrder(int userId)
		{
			try
			{

                List<OrderDetailReturn> allOrderDetail = new List<OrderDetailReturn>();
				var allOrder = context.OrderData.Where(u => u.UserId == userId).ToList();
                foreach (var order in allOrder)
				{
					OrderDetailReturn orderDetailReturn = new OrderDetailReturn();
					Book book = context.Book.SingleOrDefault(u => u.BookId == order.BookId);
					Address address = context.Address.SingleOrDefault(u => u.AddressId == order.AddressId);
					orderDetailReturn.Title = book.Title;
					orderDetailReturn.BookCode = book.Code;
					orderDetailReturn.Price = book.Price;
					orderDetailReturn.Image = book.Image;
					orderDetailReturn.Quantity= order.Quantity;
					orderDetailReturn.Amount = order.Amount;
					orderDetailReturn.DateTime = order.DateTime;
					orderDetailReturn.FullAddress = address.FullAddress;
					orderDetailReturn.City = address.City;
					orderDetailReturn.PinCode = address.PinCode;
					orderDetailReturn.State = address.State;
					allOrderDetail.Add(orderDetailReturn);
				}
				if(allOrderDetail.Count == 0)
				{
					return null;
				}
				return allOrderDetail;

			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
