using Microsoft.AspNetCore.Mvc;
using UserRegisteration.Models;

namespace UserRegisteration.Controllers
{
    public class AccountController : Controller
    {
        private UserContext Context { get; set; }

        public AccountController(UserContext userContext)
        {
            Context = userContext;
        }
      

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = Context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(User _user)
        {
            Context.Users.Remove(_user);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit User Details";
            var _user = Context.Users.Find(id);
            return View(_user);


        }
        [HttpPost]
        public IActionResult Edit(User _user)
        {
            if (ModelState.IsValid)
            {
                if (_user.UserId == 0)
                {
                    Context.Users.Add(_user);
                }
                else
                {

                    Context.Users.Update(_user);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (_user.UserId == 0) ? "Add" : "Edit";
                return View(_user);
            }

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
   

        