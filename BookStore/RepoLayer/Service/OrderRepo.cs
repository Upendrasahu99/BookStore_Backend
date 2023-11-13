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
	/// Implemented IOrderRepo abstract method
	/// </summary>
    public class OrderRepo : IOrderRepo
    {
		private readonly BookStoreContext context;

		public OrderRepo(BookStoreContext context)
		{
			this.context = context;
		}

        /// <summary>
        /// Method is implementing place order functionality which store the data in database when we place the order
        /// </summary>
        /// <param name="model">Enter requirement and detail for place order</param>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <param name="bookId">For choose for particular book</param>
        /// <param name="AddressId">For choose particular address of user</param>
        /// <returns>After placing order return order data</returns>
		public OrderDetailReturn PlaceOrder(OrderBookModel model, int userId, int bookId, int AddressId)
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
					return OrderDetail(orderData.OrderId);
				}
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

        /// <summary>
        /// Method is implemented OrderDetail functionality for which get the order detail from database.
        /// </summary>
        /// <param name="orderId">For particular orderId</param>
        /// <returns>Order detail</returns>
        public OrderDetailReturn OrderDetail(int orderId)
		{
			try
			{
				OrderData order = context.OrderData.SingleOrDefault(u => u.OrderId == orderId);
				if (order != null)
				{
					Book book = context.Book.SingleOrDefault(u => u.BookId == order.BookId);
					Address address = context.Address.SingleOrDefault(u => u.AddressId == order.AddressId);

					OrderDetailReturn orderDetailReturn = new OrderDetailReturn();
					orderDetailReturn.OrderId = orderId;
					orderDetailReturn.Title = book.Title;
					orderDetailReturn.BookCode = book.Code;
					orderDetailReturn.Price = book.Price;
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

        /// <summary>
        /// Method for implementation for GetAll Order detail functionality where it get detail of all order from database which placed by user
        /// </summary>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <returns>Return all order detail</returns>
        public List<OrderDetailReturn> GetAllOrder(int userId)
		{
			try
			{

                List<OrderDetailReturn> allOrderDetail = new List<OrderDetailReturn>();
				var allOrder = context.OrderData.Where(u => u.UserId == userId).ToList();
                foreach (var order in allOrder)
				{
					allOrderDetail.Add(OrderDetail(order.OrderId));
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


        /// <summary>
        /// Method is implemented Cancel order functionality we delete the order detail form database.
        /// </summary>
        /// <param name="orderId">for chose particular order</param>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <returns>Cancel order detail</returns>
        public OrderDetailReturn CancelOrder(int orderId, int userId)
		{
			try
			{
				OrderData order = context.OrderData.SingleOrDefault(u => u.OrderId == orderId && u.UserId == userId);
				if (order != null) 
				{
					OrderDetailReturn orderDetailReturn = OrderDetail(orderId);
					context.OrderData.Remove(order);
					context.SaveChanges();
				/*	OrderDetailReturn orderDetailReturn = new OrderDetailReturn();
                    Book book = context.Book.SingleOrDefault(u => u.BookId == order.BookId);
                    Address address = context.Address.SingleOrDefault(u => u.AddressId == order.AddressId);
                    orderDetailReturn.Title = book.Title;
                    orderDetailReturn.BookCode = book.Code;
					orderDetailReturn.Price = book.Price;
                    orderDetailReturn.Quantity = order.Quantity;
                    orderDetailReturn.Amount = order.Amount;
                    orderDetailReturn.DateTime = order.DateTime;
                    orderDetailReturn.FullAddress = address.FullAddress;
                    orderDetailReturn.City = address.City;
                    orderDetailReturn.PinCode = address.PinCode;
                    orderDetailReturn.State = address.State;*/
					return orderDetailReturn;
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
