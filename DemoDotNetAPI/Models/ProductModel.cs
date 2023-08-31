using System;

namespace DemoDotNetAPI.Models
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string TypeName { get; set; }
        public byte Discount { get; set; }
        public int? TypeId { get; set; }
    }
}
