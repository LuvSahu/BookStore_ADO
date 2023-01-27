using BusinessLayer.Interfaces;
using CommonLayer.OrderModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrderBL :IOrderBL
    {
        private readonly IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public bool AddOrder(OrderDataModel postModel)
        {
            try
            {
                return orderRL.AddOrder(postModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GetOrderModel> GetAllOrders(int UserId)
        {
            try
            {
                return orderRL.GetAllOrders(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteOrderItem(int UserId, int OrderId)
        {
            try
            {
                return this.orderRL.DeleteOrderItem(UserId, OrderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
