using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Entity
{
    public class MemberBorrow
    {
        [Key]
        public int Id { get; set; }
        
        public virtual int MemberId   { get; set; }
       
        public virtual int BookId { get; set; }

        [Required]
        public DateTime Checkouttime { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [ForeignKey("MemId")]
        public virtual Member Member { get; set; }

    }
}
