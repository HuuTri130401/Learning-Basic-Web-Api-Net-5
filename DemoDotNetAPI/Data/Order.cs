using System;
using System.Collections.Generic;

namespace DemoDotNetAPI.Data
{
    public enum StatusOrder
    {
        New = 0, Payment = 1, Completed = 2, Cancel = -1
    }

    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public string Recipient { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
