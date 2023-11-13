using CommonLayer.Model;
using CommonLayer.ReturnModel;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBusiness
    {
        /// <summary>
        /// Functionality for placeOrder.
        /// </summary>
        /// <param name="model">Enter requirement and detail for place order</param>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <param name="bookId">For choose for particular book</param>
        /// <param name="AddressId">For choose particular address of user</param>
        /// <returns>After placing order return order data</returns>
        public OrderData PlaceOrder(OrderBookModel model, int userId, int bookId, int AddressId);

        /// <summary>
        /// For get order detail
        /// </summary>
        /// <param name="orderId">For particular orderId</param>
        /// <returns>Order detail</returns>
        public OrderDetailReturn OrderDetail(int orderId);

        /// <summary>
        /// For get all order of user
        /// </summary>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <returns>Return all order detail</returns>
        public List<OrderDetailReturn> GetAllOrder(int userId);

        /// <summary>
        /// For cancel order of user
        /// </summary>
        /// <param name="orderId">for chose particular order</param>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <returns>Cancel order detail</returns>
        public OrderDetailReturn CancelOrder(int orderId, int userId);
    }
}
