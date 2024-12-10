using LMS.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
namespace LMS.DBContext
{
    public class LMSContext(DbContextOptions<LMSContext> options) : DbContext(options)
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserCheckouts> UserCheckouts { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Added this to mitigate an error while running update-database command
            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));

            optionsBuilder.UseSqlServer("Server=IRIS\\SQLEXPRESS;Database=LMS;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}

