using _26_BuiVanToan_BusinessObject;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_BuiVanToan_BusinessObject.DTO
{
    public class ProductRequest
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int UnitPrice { get; set; }
        [Required]

        public int Weight { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int UnitsInStock { get; set; }
   
        [Required]
        public int CategoryId { get; set; }
  
 
  
  
    }
}

