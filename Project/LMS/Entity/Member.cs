using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Entity
{
    public class Member
    {
        [Key]
        public int MemId { get; set; }

        [Required]
        [MaxLength(150)]
        public string MemberFullname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(12)]
        public string UserPassword { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public DateTime Membersince { get; set; }

        [Required]
        public DateTime birthdate { get; set; }

        //this is always member for a member
        [Required]        
        public virtual int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Roles Roles { get; set; }


    }
}
