using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _26_BuiVanToan_BusinessObject
{
    public class BookAuthor
    {
        [Key]
        [ForeignKey("Author")]
        public  int AuthorId { get; set; }
        [Key]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public int AuthorOrder {  get; set; }
        [Required]
        public  int RoyalityPercentage { get; set; }
        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }

    }
}
