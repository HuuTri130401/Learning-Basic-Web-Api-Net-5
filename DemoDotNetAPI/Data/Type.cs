using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDotNetAPI.Data
{
    [Table("Types")]
    public class Type
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
