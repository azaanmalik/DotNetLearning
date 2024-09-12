using Microsoft.AspNetCore.Mvc;
using UserRegisteration.Models;

namespace UserRegisteration.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                var existingEmail = _userContext.Users.FirstOrDefault(u => u.UserEmail == user.UserEmail);
                if (existingEmail != null)
                {
                    ModelState.AddModelError("", "User Email already exists");
                    return View(user);
                }

                _userContext.Users.Add(user);
                _userContext.SaveChanges();
                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                var existingUser = _userContext.Users
                    .FirstOrDefault(u => u.UserEmail == user.UserEmail && u.Password == user.Password);

                if (existingUser != null)
                {
                    // Store user details in session
                    HttpContext.Session.SetString("UserEmail", existingUser.UserEmail);
                    HttpContext.Session.SetString("UserName", existingUser.UserName);
                    HttpContext.Session.SetString("Gender", existingUser.Gender ?? "");
                    HttpContext.Session.SetString("DateOfBirth", existingUser.Date_of_Birth?.ToString("yyyy-MM-dd") ?? "");

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid User Name or Password");
            }

            return View(user);
        }

        
    }
}
