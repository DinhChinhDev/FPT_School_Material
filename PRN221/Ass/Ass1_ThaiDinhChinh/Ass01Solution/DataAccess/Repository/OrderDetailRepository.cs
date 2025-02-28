using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(int id)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                OrderDetail? deletedOrderDetail = context.OrderDetails.FirstOrDefault(o => o.OrderId == id) ?? throw new Exception("No order detail was found!");
                context.OrderDetails.Remove(deletedOrderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<OrderDetail> GetAll()
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public OrderDetail GetById(int id)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.OrderDetails.FirstOrDefault(o => o.OrderId == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                context.Entry(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
