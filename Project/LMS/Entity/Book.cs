using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Net;

namespace LMS.Entity
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(150)]
        public string BookTitle { get; set; }

        [Required]
        [MaxLength(50)]
        public string ISBN { get; set; }

        [Required]
        [MaxLength(50)]
        public string AuthorName { get; set; }
        //public Image BookPhoto { get; set; }

        public int PublishYear { get; set; }

        [Required]     
        public virtual int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual BookCategory BookCategory { get; set; }     
       
    }
}
