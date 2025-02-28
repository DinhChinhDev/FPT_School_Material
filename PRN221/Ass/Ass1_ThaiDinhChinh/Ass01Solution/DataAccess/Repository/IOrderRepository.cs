using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetAll();
        public Order GetById(int id);
        public void DeleteOrder(int id);
        public void UpdateOrder(Order order);
        public void InsertOrder(Order order);

    }
}
