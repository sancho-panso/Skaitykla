using Microsoft.AspNetCore.Mvc;
using Skaitykla._Domain;
using Skaitykla._EF;
using Skaitykla.MVC.Models;
using Skaitykla.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skaitykla.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly BookContext _db;

        public AuthController(BookContext db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(e => e.Email == model.Email);
              
                if (user == null)
                {
                    TempData["shortMessage"] = "Not such user found, do you wanna make registration on our site?";
                    TempData["Regist"] = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    if (user.IsAdmin && user.Email == model.Email && user.Password == model.Password)
                    {
                        return RedirectToAction("Index", "Admin");
                    } 
                    if (user.Password == model.Password)
                    {
                        ViewBag.Message = "Thanks";
                        return View(user);
                    }
                    TempData["shortMessage"] = "wrong password";
                    return RedirectToAction("Index");

                }
            }
            TempData["shortMessage"] = "wrong password or email";
            return RedirectToAction("Index");

        }

        public ActionResult Index()
        {
            if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
                
            }
            if (TempData["Regist"] != null)
            {
                ViewBag.Registration = TempData["Regist"];
            }
            else
            {
                ViewBag.Registration = false;

            }


            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult AddRegistration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User();
                newUser.Name = model.Name;
                newUser.Email = model.Email;
                newUser.Password = model.Password;
                newUser.IsAdmin = false;

                _db.Users.Add(newUser);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}


