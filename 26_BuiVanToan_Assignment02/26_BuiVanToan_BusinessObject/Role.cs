using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_BuiVanToan_BusinessObject
{
    public class Role
    {
        public Role() { 
        Users = new HashSet<User>();

                }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoleId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string RoleDesc { get; set; }
         public ICollection<User> Users { get; set; }
    }
}
