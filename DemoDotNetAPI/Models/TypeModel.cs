using System.ComponentModel.DataAnnotations;

namespace DemoDotNetAPI.Models
{
    public class TypeModel
    {
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}
