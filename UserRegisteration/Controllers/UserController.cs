using Microsoft.AspNetCore.Mvc;
using UserRegisteration.Models;

namespace UserRegisteration.Controllers
{
    public class UserController : Controller
    {
        private UserContext _userContext { get; set; } = null!;

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
            if (ModelState.IsValid) {
                var ExistingEmail = _userContext.Users.FirstOrDefault(u => u.UserEmail == user.UserEmail);
                if (ExistingEmail != null)
                {
                    ModelState.AddModelError("", "User Email already Exist");
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
                var ExistingEmail = _userContext.Users.FirstOrDefault(u => u.UserEmail == user.UserEmail && u.Password == user.Password);
                if (ExistingEmail != null)
                {
                    return RedirectToAction("Index", "Home");
                    
                }
                ModelState.AddModelError("", "Invalid User Name or Password");
                return View(user);
            }
            return View(user);

        }



    }
}
