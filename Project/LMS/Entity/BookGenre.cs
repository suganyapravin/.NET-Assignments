using System.ComponentModel.DataAnnotations;

namespace LMS.Entity
{
    public class BookGenre
    {
        [Key]
        public int Id { get; set; }
        public string Genre { get; set; }
    }
}
