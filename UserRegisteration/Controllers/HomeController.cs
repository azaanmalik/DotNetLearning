using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserRegisteration.Models;
using System.Linq;

namespace UserRegisteration.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext UserContext;

        public HomeController(UserContext userContext)
        {
            UserContext = userContext;
        }

        public IActionResult Index()
        {
            // Retrieve user details from the session
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "User");
            }

            var user = UserContext.Users.FirstOrDefault(u => u.UserEmail == userEmail);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            // Pass data to the view
            ViewBag.UserEmail = user.UserEmail;
            ViewBag.UserName = user.UserName;
            ViewBag.Gender = user.Gender;
            ViewBag.DateOfBirth = user.Date_of_Birth?.ToString("yyyy-MM-dd") ?? string.Empty; 
            
            return View(user);
        }

        
    }
}
