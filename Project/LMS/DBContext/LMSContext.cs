using LMS.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Entity.Migrations;
using Microsoft.Extensions.Options;
using System.Data;
namespace LMS.DBContext
{
    public class LMSContext(DbContextOptions<LMSContext> options) : DbContext(options)
    {

        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RoleViews> RoleViews { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Member> Members { get; set; }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<MemberBorrow> MemberBorrow { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Added this to mitigate an error while running update-database command
            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));

            optionsBuilder.UseSqlServer("Server=IRIS\\SQLEXPRESS;Database=LMS;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            #region seed data

            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleID = 1, Name = "Librarian", IsActive = true, CreatedBy = 0, CreatedDate = DateTime.UtcNow, UpdatedBy = 0 },
                new Roles { RoleID = 2, Name = "Staff", IsActive = true, CreatedBy = 0, CreatedDate = DateTime.UtcNow, UpdatedBy = 0 },
                 new Roles { RoleID = 3, Name = "Member", IsActive = true, CreatedBy = 0, CreatedDate = DateTime.UtcNow, UpdatedBy = 0 }
            );
            modelBuilder.Entity<BookCategory>().HasData(
               new BookCategory { CategoryId = 1, CategoryName = "Action" },
              new BookCategory { CategoryId = 2, CategoryName = "Drama" },
              new BookCategory { CategoryId = 3, CategoryName = "Thriller" }
              );

            modelBuilder.Entity<Views>().HasData(
              new Views { Id = 1, VName = "Add Staff" },
             new Views { Id = 2, VName = "Add Books" },
             new Views { Id = 3, VName = "View Reports" }
             );

            //modelBuilder.Entity<RoleViews>().HasData(
            //  new RoleViews { Id = 1, RoleId = 1, ViewID = 1 }
            // );
            #endregion
        }
    }
}

