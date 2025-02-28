using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess
{
    public class OrderDAO
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDAO(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepository.GetById(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
                _orderRepository.Delete(order);
        }

        public List<Order> GetOrdersByMemberId(int memberId)
        {
            var orders = _orderRepository.GetAll();
            List<Order> return_orders = new List<Order>();
            foreach (var order in orders)
            {
                if (order.MemberId == memberId)
                {
                    return_orders.Add(order);
                }
            }
            return return_orders;
        }

        public int GetMaxId()
        {
            var orderList = GetAllOrders();
            int id = 0;
            foreach (var order in orderList)
            {
                if (order.OrderId > id)
                {
                    id = order.OrderId;
                }
            }
            return id;
        }

        public IEnumerable<Order> GetSalesDataByPeriod(DateTime startDate, DateTime endDate)
        {
            try
            {
                var orderList = GetAllOrders().Where(order => order.OrderDate >= startDate && order.OrderDate <= endDate);
                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
