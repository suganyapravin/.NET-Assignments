using FirstMVCApp.ViewModel;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace FirstMVCApp.Controllers
{
    public class TestController : Controller
    {

     
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Menu(UserViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
              return View();
        }
        [HttpPost]
        public IActionResult AddUser(UserViewModel model)
        {

            var dbContextOption = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer("Server=IRIS\\SQLEXPRESS;Database=Suganya;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;
            using var context = new DatabaseContext(dbContextOption);
            context.UserViewModel.Add(model);
            context.SaveChanges();
            return View();
        }
       
        [HttpGet]
        public IActionResult List()
        {
            var dbContextOption = new DbContextOptionsBuilder<DatabaseContext>()
               .UseSqlServer("Server=IRIS\\SQLEXPRESS;Database=Suganya;Trusted_Connection=True;TrustServerCertificate=True")
               .Options;
            using var context = new DatabaseContext(dbContextOption);
            return View(context.Set<UserViewModel>().ToList());           
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var dbContextOption = new DbContextOptionsBuilder<DatabaseContext>()
               .UseSqlServer("Server=IRIS\\SQLEXPRESS;Database=Suganya;Trusted_Connection=True;TrustServerCertificate=True")
               .Options;
            using var context = new DatabaseContext(dbContextOption);
            
            return View(context.Set<UserViewModel>().Find(id));
        }
        [HttpPost]
        public IActionResult EditUser(UserViewModel model)
        {
            var dbContextOption = new DbContextOptionsBuilder<DatabaseContext>()
               .UseSqlServer("Server=IRIS\\SQLEXPRESS;Database=Suganya;Trusted_Connection=True;TrustServerCertificate=True")
               .Options;          
            using var context = new DatabaseContext(dbContextOption);
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var dbContextOption = new DbContextOptionsBuilder<DatabaseContext>()
              .UseSqlServer("Server=IRIS\\SQLEXPRESS;Database=Suganya;Trusted_Connection=True;TrustServerCertificate=True")
              .Options;
            using var context = new DatabaseContext(dbContextOption);
            var model = context.Set<UserViewModel>().Find(id);
            context.Set<UserViewModel>().Remove(model);
            context.SaveChanges();
            return RedirectToAction("List");

        }        

    }
}
