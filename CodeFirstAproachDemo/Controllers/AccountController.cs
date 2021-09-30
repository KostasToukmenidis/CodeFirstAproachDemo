using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstAproachDemo.Models;
using CodeFirstAproachDemo.ViewModels;

namespace CodeFirstAproachDemo.Controllers
{
    public class AccountController : Controller
    {
        private GunStoreDbContext _context;

        public AccountController()
        {
            _context = new GunStoreDbContext();
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View("Register", user);

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "E-mail already taken, try another one");
                return View("Register", user);
            }
            else if (_context.Users.Any(u => u.UserName == user.UserName))
            {
                ModelState.AddModelError("UserName", "User Name already taken, try another one");
                return View("Register", user);
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            var loginUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (loginUser == null)
            {
                ModelState.AddModelError("Password", "User Name or Password is incorrect");
                return View("Login", user);
            }
            else
            {
                Session["UserName"] = loginUser.UserName;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}