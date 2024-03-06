using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_BuiVanToan_BusinessObject
{
    public class Book

    {
        public Book() {
            BookAuthors = new HashSet<BookAuthor>();

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]

        public string Title { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Type { get; set; }
        [ForeignKey("Publisher")]
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MinLength(2)]
        [MaxLength(255)]
        public string Advance { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(55)]
        public string Royalty { get; set; }
        [Required]
        public int YtdSales { get; set; }
        [MinLength(2)]
        [MaxLength(255)]
        public string Note { get; set; }
        [Required]
        [DataType(DataType.DateTime)]

        public DateTime PublisherDate { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set;}
    }
}
