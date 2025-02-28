using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailDAO(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public OrderDetail GetOrderDetailById(int orderId, int productId)
        {
            return _orderDetailRepository.GetById(orderId, productId);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailRepository.GetAll();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Add(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Update(orderDetail);
        }

        public void DeleteOrderDetail(int orderId, int productId)
        {
            var orderDetail = _orderDetailRepository.GetById(orderId, productId);
            if (orderDetail != null)
                _orderDetailRepository.Delete(orderDetail);
        }

        public void DeleteByOrderId(int orderId)
        {
            var orderDetails = _orderDetailRepository.GetAll();
            foreach(var orderDetail in orderDetails)
            {
                if(orderDetail.OrderId == orderId)
                {
                    _orderDetailRepository.Delete(orderDetail);
                }
            }
        }
    }
}
