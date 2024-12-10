using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Entity
{
    public class UserCheckouts
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId   { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public DateTime Checkouttime { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }

    }
}
