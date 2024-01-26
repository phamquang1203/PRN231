using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_BusinessObject.DTO;
using System.ComponentModel.DataAnnotations;

namespace _26_BuiVanToan_BusinessObject.DTO
{
    public class OrderItemRequest
    {
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
