using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_BuiVanToan_BusinessObject
{
    public class Author

    {
        public Author() {
            BookAuthors = new HashSet<BookAuthor>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AuthorId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string FirstName { get; set; }
        public string Phone {  get; set; }
        [MinLength(2)]
        [MaxLength(255)]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }


    }
}
