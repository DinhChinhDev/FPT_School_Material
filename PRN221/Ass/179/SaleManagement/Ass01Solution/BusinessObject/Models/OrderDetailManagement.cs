using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class OrderDetailManagement
    {
        private static OrderDetailManagement instance = null;
        public static readonly object instanceLock = new object();

        private OrderDetailManagement() { }
        public static OrderDetailManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailManagement();
                    }
                    return instance;
                }
            }
        }


        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> OrderDetails;
            try
            {
                var myContextDB = new PRN221_As01Context();
                OrderDetails = myContextDB.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetails;
        }

        public OrderDetail GetOrderDetailByID(int id)
        {
            OrderDetail OrderDetail = null;
            try
            {
                var myContextDB = new PRN221_As01Context();
                OrderDetail = myContextDB.OrderDetails.SingleOrDefault(item => item.OrderId == id );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetail;
        }

        public OrderDetail GetOrderDetailByIDAndProductID(int id, int pid)
        {
            OrderDetail OrderDetail = null;
            try
            {
                var myContextDB = new PRN221_As01Context();
                OrderDetail = myContextDB.OrderDetails.SingleOrDefault(item => item.OrderId == id && item.ProductId == pid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetail;
        }

        public void AddNew(OrderDetail OrderDetail)
        {
            try
            {

                var myContextDB = new PRN221_As01Context();
                myContextDB.OrderDetails.Add(OrderDetail);
                myContextDB.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail currentOrderDetail = GetOrderDetailByIDAndProductID(OrderDetail.OrderId, OrderDetail.ProductId);
                if (currentOrderDetail != null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Entry(OrderDetail).State = EntityState.Modified;
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail currentOrderDetail = GetOrderDetailByID(OrderDetail.OrderId);
                if (currentOrderDetail != null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.OrderDetails.Remove(OrderDetail);
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
