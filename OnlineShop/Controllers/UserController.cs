using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.Entities;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /User/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterAsync(user);
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // GET: /User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var isAuthenticated = await _userService.LoginAsync(email, password);
                if (isAuthenticated)
                {
                    return RedirectToAction("Index", "Home"); // Redirect to home page or dashboard
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View();
        }

        // GET: /User/ResetPassword
        public IActionResult ResetPassword()
        {
            return View();
        }

        // POST: /User/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string email, string oldPassword, string newPassword)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.ResetPasswordAsync(email, oldPassword, newPassword);
                    return RedirectToAction("Login"); // Redirect to login after successful password reset
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View();
        }

        // GET: /User/ChangeStatus
        public IActionResult ChangeStatus()
        {
            return View();
        }

        // POST: /User/ChangeStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(string email, bool status)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.ChangeStatusAsync(email, status);
                    return RedirectToAction("Index", "Home"); // Redirect after status change
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View();
        }
    }
}
