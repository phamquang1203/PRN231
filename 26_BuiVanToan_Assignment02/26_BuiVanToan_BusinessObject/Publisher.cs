using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_BuiVanToan_BusinessObject
{
    public class Publisher
    {
        public Publisher() {
            Books = new HashSet<Book>();
            Users = new HashSet<User>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PublisherId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string PublisherName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string City { get; set;}
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string State { get; set;}
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Country { get; set;}
        public ICollection<Book> Books { get; set;}
        public ICollection<User> Users { get; set;}
    }
}
