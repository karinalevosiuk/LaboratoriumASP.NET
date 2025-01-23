using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private static readonly Dictionary<string, string> Users = new Dictionary<string, string>
        {
            { "admin", "adminpassword" },
            { "user1", "password1" },
            { "user2", "password2" }
        };
        
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            if (ValidateUser(username, password))
            {
                HttpContext.Session.SetString("Username", username);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }
        
        
       
        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");

            return RedirectToAction("Login");
        }

        private bool ValidateUser(string username, string password)
        {
            return Users.ContainsKey(username) && Users[username] == password;
        }
    }


}