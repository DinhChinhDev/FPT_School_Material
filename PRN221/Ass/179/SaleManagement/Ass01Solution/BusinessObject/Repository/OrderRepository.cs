using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order Order)
        {
            OrderManagement.Instance.Remove(Order);
        }

        public Order GetOrderByID(int id)
        {
            return OrderManagement.Instance.GetOrderByID(id);
        }


        public IEnumerable<Order> GetOrders()
        {
            return OrderManagement.Instance.GetOrderList();
        }

        public void InsertOrder(Order Order)
        {
            OrderManagement.Instance.AddNew(Order);
        }


        public void UpdateOrder(Order Order)
        {
            OrderManagement.Instance.Update(Order);
        }
    }
}
