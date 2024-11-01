using DataAccessLayer.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comment(int pageNumber = 1)
        {
            
            return View(db.Comment.ToList().ToPagedList(pageNumber, 5));
        }

        public ActionResult DeleteComment(int id)
        {
            var itemToDelete = db.Comment.Where(x => x.Id == id).FirstOrDefault();
            db.Comment.Remove(itemToDelete);
            return RedirectToAction("Index");
        }
    }
}