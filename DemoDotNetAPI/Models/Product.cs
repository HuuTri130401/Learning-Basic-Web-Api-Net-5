using System;

namespace DemoDotNetAPI.Models
{
    public class ProductVM
    {
        public string NameProduct { get; set; }
        public double Price { get; set; }
    }

    public class Product : ProductVM
    {
        public Guid CodeProduct { get; set; }
    }
}
