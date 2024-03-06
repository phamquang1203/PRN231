using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_BuiVanToan_BusinessObject
{
    public class User

    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(30)]
        public string Password { get; set; }
        [MinLength(2)]
        [MaxLength(255)]
        public string Source { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string MiddleName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [DataType (DataType.DateTime)]
        public DateTime HireDate { get; set; }
        [ForeignKey("Role")]
        [Required]
        public int RoleId { get; set; }
        [ForeignKey("Publisher")]
        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Role Role { get; set; }
    }
}
