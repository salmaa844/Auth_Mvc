using Auth_mvc.Data;
using Auth_mvc.Migrations;
using Auth_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth_mvc.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()

        {
            var user = context.Users.Where(u => u.IsActione == false).ToList();

            return View("Index", user);
        }
       
        [HttpPost]
        public IActionResult Index(Guid userid)
        {
          
            var user = context.Users.FirstOrDefault(u => u.UserId == userid);
            if (user != null)
            {
               
                user.IsActione = true;
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var checkUser = context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password);
            if (checkUser.Any())
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = "Invaled username / password";
            return View(user);

        }
    }
}
