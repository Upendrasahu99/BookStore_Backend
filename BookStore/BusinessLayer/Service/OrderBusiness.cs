using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.ReturnModel;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{

	/// <summary>
	/// Implement IOrderBusiness
	/// </summary>
    public class OrderBusiness : IOrderBusiness
    {
		private readonly IOrderRepo orderRepo;
		public OrderBusiness(IOrderRepo orderRepo)
		{
			this.orderRepo = orderRepo;
		}

        /// <summary>
        /// Implement PlaceOrder method
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
				return orderRepo.PlaceOrder(model, userId, bookId, AddressId);
			}
			catch (Exception)
			{

				throw;
			}
        }


        /// <summary>
        /// Implement OrderDetail method
        /// </summary>
        /// <param name="orderId">For particular orderId</param>
        /// <returns>Order detail</returns>
        public OrderDetailReturn OrderDetail(int orderId)
		{
			try
			{
				return orderRepo.OrderDetail(orderId);
			}
			catch (Exception)
			{

				throw;
			}
		}

        /// <summary>
        /// Implement GetAllOrder method
        /// </summary>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <returns>Return all order detail</returns>
        public List<OrderDetailReturn> GetAllOrder(int userId)
		{
			try
			{
				return orderRepo.GetAllOrder(userId);
			}
			catch (Exception)
			{

				throw;
			}
		}

        /// <summary>
        /// Implement CancelOrder method
        /// </summary>
        /// <param name="orderId">for chose particular order</param>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <returns>Cancel order detail</returns>
        public OrderDetailReturn CancelOrder(int orderId, int userId)
        {
			try
			{
				return orderRepo.CancelOrder(orderId, userId);
			}
			catch (Exception)
			{

				throw;
			}
		}
    }
}
