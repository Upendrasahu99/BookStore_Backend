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
    public class OrderBusiness : IOrderBusiness
    {
		private readonly IOrderRepo orderRepo;
		public OrderBusiness(IOrderRepo orderRepo)
		{
			this.orderRepo = orderRepo;
		}
        public OrderData PlaceOrder(OrderBookModel model, int userId, int bookId, int AddressId)
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
    }
}
