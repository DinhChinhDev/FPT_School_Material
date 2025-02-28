using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(int id)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                Order? deletedOrder = context.Orders.FirstOrDefault(o => o.OrderId == id) ?? throw new Exception("No order was found!");
                context.Orders.Remove(deletedOrder);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Order> GetAll()
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.Orders.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Order GetById(int id)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.Orders.FirstOrDefault(o => o.OrderId == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertOrder(Order order)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
