using System;
using System.Collections.Generic;

namespace DemoDotNetAPI.Data
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Total { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }

        //RelationShip
        public Order Order { get; set; }
        public Product Product { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
