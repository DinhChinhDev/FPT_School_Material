using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetAll();
        public OrderDetail GetById(int id);
        public void DeleteOrderDetail(int id);
        public void UpdateOrderDetail(OrderDetail orderDetail);
        public void InsertOrderDetail(OrderDetail orderDetail);

    }
}
