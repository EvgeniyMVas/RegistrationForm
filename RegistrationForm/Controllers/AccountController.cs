using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Data;
using RegistrationForm.Models;
using System;

namespace RegistrationForm.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new User();
            ViewData["UserName"] = TempData["UserName"].ToString();
            return View(model); 
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register( User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                TempData["UserName"] = user.UserName;
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        public IActionResult IsUserNameAvailable(string username)
        {
            bool flag=!_context.User.Any(e=>e.UserName==username);
            if (!flag)
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
