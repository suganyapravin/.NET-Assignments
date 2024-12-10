using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Entity
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
       // public DateTime UpdatedDate { get; set; }      

    }
    public class BookCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

    }
    public class Views
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string VName { get; set; }

    }
    public class RoleViews
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        [NotMapped]
        public virtual Roles Roles { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int ViewID { get; set; }

       public virtual Views Views { get; set; }

    }



}
