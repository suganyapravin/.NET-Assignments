using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace LMS.Entity
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }       
        public string ISBN { get; set; }
        public int PublishYear { get; set; }

        [ForeignKey("Id")]
        public int GenreId { get; set; }

       // [ForeignKey("PublisherId")]
       // public int PublisherId { get; set; }

        [ForeignKey("AuthorID")]
        public int AuthorID { get; set; }
        public virtual BookGenre BookGenre { get; set; }
        public virtual Author Author { get; set; }
       
    }
}
