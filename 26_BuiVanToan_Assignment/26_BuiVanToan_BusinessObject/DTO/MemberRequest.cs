using System.ComponentModel.DataAnnotations;

namespace _26_BuiVanToan_BusinessObject.DTO
{
    public class MemberRequest
    {
        public int MemberId { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string? Country { get; set; }

        public string? Password { get; set; }
    }
}