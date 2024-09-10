using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserRegisteration.Models;

namespace UserRegisteration.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _userContext { get; set; } = null!;

        public HomeController(UserContext userContext)
        {
            _userContext = userContext;
        }

        public IActionResult Index()
        { 
            return View();
        }
    }
}
