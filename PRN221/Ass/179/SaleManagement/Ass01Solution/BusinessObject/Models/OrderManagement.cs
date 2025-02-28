using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class OrderManagement
    {

        private static OrderManagement instance = null;
        public static readonly object instanceLock = new object();

        private OrderManagement() { }
        public static OrderManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderManagement();
                    }
                    return instance;
                }
            }
        }


        public IEnumerable<Order> GetOrderList()
        {
            List<Order> Orders;
            try
            {
                var myContextDB = new PRN221_As01Context();
                Orders = myContextDB.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Orders;
        }

        public Order GetOrderByID(int id)
        {
            Order Order = null;
            try
            {
                var myContextDB = new PRN221_As01Context();
                Order = myContextDB.Orders.SingleOrDefault(item => item.OrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Order;
        }

        public void AddNew(Order Order)
        {
            try
            {
                Order currentOrder = GetOrderByID(Order.OrderId);
                if (currentOrder == null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Orders.Add(Order);
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Order Order)
        {
            try
            {
                Order currentOrder = GetOrderByID(Order.OrderId);
                if (currentOrder != null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Entry(Order).State = EntityState.Modified;
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Order Order)
        {
            try
            {
                Order currentOrder = GetOrderByID(Order.OrderId);
                if (currentOrder != null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Orders.Remove(Order);
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
