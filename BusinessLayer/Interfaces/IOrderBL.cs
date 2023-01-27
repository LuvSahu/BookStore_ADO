using CommonLayer.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrderBL
    {
        public bool AddOrder(OrderDataModel postModel);
        public List<GetOrderModel> GetAllOrders(int UserId);

        public bool DeleteOrderItem(int UserId, int OrderId);

    }
}
