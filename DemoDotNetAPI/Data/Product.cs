using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDotNetAPI.Data
{
    [Table("Products")] //Ten table trong DB
    public class Product
    {
        [Key] // Khoa Chinh
        public Guid Id { get; set; }
        [Required] //Bat buoc nhap trong DB
        [MaxLength(100)]
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public byte Discount { get; set; }
        public int? TypeId { get; set; } //foreign key co the co hoac khong
        [ForeignKey("MaLoai")]
        public Type Type { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Product() 
        { 
            OrderDetails = new List<OrderDetail>();
        }
    }
}
