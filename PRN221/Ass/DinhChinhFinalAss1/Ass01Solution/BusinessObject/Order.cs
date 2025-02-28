using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Order(int memberId, DateTime orderdate, DateTime requiredDate, DateTime shippedDate, decimal freight)
        {
            MemberId = memberId;
            OrderDate = orderdate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            Freight = freight;
        }

        public Order(int orderId, int memberId, DateTime orderdate, DateTime requiredDate, DateTime shippedDate, decimal freight)
        {
            OrderId = orderId;
            MemberId = memberId;
            OrderDate = orderdate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            Freight = freight;
        }

        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
