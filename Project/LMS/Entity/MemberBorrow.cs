using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Entity
{
    public class MemberBorrow
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MemId")]
        public int MemberId   { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }

        [Required]
        public DateTime Checkouttime { get; set; }

      //  [NotMapped]
        public virtual IEnumerable<Book> Book { get; set; }

      //  [NotMapped]
        public virtual IEnumerable<Member> Member { get; set; }

    }
}
