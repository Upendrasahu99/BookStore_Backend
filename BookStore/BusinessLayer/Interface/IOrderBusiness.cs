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
        public OrderData PlaceOrder(OrderBookModel model, int userId, int bookId, int AddressId);
        public OrderDetailReturn OrderDetail(int orderId);
        public List<OrderDetailReturn> GetAllOrder(int userId);
    }
}
