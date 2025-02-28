using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailManagement.Instance.Remove(orderDetail);
        }

        public OrderDetail GetOrderDetailByID(int id)
        {
            return OrderDetailManagement.Instance.GetOrderDetailByID(id);
        }


        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return OrderDetailManagement.Instance.GetOrderDetailList();
        }

        public void InsertOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailManagement.Instance.AddNew(orderDetail);
        }


        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailManagement.Instance.Update(orderDetail);
        }

    }
}
