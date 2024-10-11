using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using PagedList.Mvc;
using PagedList;

namespace WebApplication1.Controllers
{
    public class AdminProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public ActionResult Index(int page = 1)
        {
            return View(productRepository.List().ToPagedList(page, 3));
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            List<SelectListItem> categories = (from i in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.Categories = categories;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir hata oluştu.");
                return View();
            }
            
            List<SelectListItem> categories = (from i in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;


            string path = Path.Combine("~/Content/Image/", file.FileName);
            file.SaveAs(Server.MapPath(path));
            p.Image = file.FileName.ToString();

            productRepository.Insert(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var objectToDelete = productRepository.GetById(id);
            productRepository.Delete(objectToDelete);
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> categories = (from i in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;
            var objectToUpdate = productRepository.GetById(id);
            return View(objectToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product p, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir hata oluştu.");
                return View();
            }
            List<SelectListItem> category = (from i in db.Categories.ToList()
                                             select new SelectListItem{
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.Category = category;

            var updatedObject = productRepository.GetById(p.Id);
            updatedObject.Name = p.Name;
            updatedObject.Description = p.Description;
            updatedObject.Stock = p.Stock;
            updatedObject.Price = p.Price;
            updatedObject.isApproved = p.isApproved;
            updatedObject.Popular = p.Popular;
            updatedObject.Category = p.Category;
            updatedObject.CategoryId = p.CategoryId;
            if (file != null)
            {
                updatedObject.Image = file.FileName.ToString();
                string path = Path.Combine("~/Content/Image/", file.FileName);
                file.SaveAs(Server.MapPath(path));
            }

            productRepository.Update(updatedObject);
            return RedirectToAction("Index");
        }
    }
}