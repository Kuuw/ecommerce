using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DataContext db = new DataContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User data)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["Mail"] = user.Email.ToString();
                Session["Name"] = user.Name.ToString();
                Session["Surname"] = user.Surname.ToString();
                Session["userid"] = user.Id.ToString();
                return RedirectToActionPermanent("Index", "Home");
            }
            ViewBag.error = "Email ve parola hatalı.";
            return View();
        }

        [HttpPost]
        public ActionResult Register(User data)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == data.Email || x.Username == data.Username);
            if (user != null && ModelState.IsValid)
            {
                db.Users.Add(user);
                data.Role = "User";
                db.SaveChanges();
                return RedirectToActionPermanent("Login", "Account");
            }
            ViewBag.error = "Bu email veya kullanıcı adını kullanan bir hesap halihazırda mevcut.";
            return View();
        }

        [HttpPost]
        public ActionResult Logout(User data)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}