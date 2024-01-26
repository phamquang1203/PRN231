using System.ComponentModel.DataAnnotations;

namespace _26_BuiVanToan_BusinessObject.DTO
{
    public class OrderReq
    {
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
   
        [Required]
        public string Freight { get; set; }
        [Required]
        public int MemberId { get; set; }
    }
}
