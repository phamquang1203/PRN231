using System.ComponentModel.DataAnnotations;

namespace _26_BuiVanToan_BusinessObject.DTO
{
    public class OrderDetailRequest
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Discount { get; set; }
    }
}
