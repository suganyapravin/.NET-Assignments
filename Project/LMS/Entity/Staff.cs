using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Entity
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        [MaxLength(100)]
        public string StaffFullname { get; set; }

        [Required]
        [MaxLength(50)]
        public string StaffUsername { get; set; }

        [Required]
        [MaxLength(12)]
        public string UserPassword { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        public DateTime joiningdate { get; set; }

        [Required]
        public DateTime birthdate { get; set; }

        [Required]
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        //[NotMapped]
        public virtual Roles Roles { get; set; }


    }
}
