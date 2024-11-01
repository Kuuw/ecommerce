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
            return View(productRepository.AdminList().ToPagedList(page, 3));
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
            // Populate categories for the dropdown list
            List<SelectListItem> categories = (from i in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;

            

            // Save the file and set the image path
            string path = Path.Combine("~/Content/Image/", file.FileName);
            file.SaveAs(Server.MapPath(path));
            p.Image = file.FileName.ToString();

            // Insert the product into the database
            productRepository.Insert(p);
            ProductStock productStock = new ProductStock();

            // Add Stock
            productStock.Id = p.Id;
            productStock.Stock = 0;
            db.ProductStocks.Add(productStock);
            db.SaveChanges();

            // Redirect to Index after successful insertion
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var objectToDelete = productRepository.GetById(id);
            productRepository.Delete(objectToDelete);

            var productStock = db.ProductStocks.FirstOrDefault(x => x.Id == id);
            db.ProductStocks.Remove(productStock);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

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
        public ActionResult Update(Product p, HttpPostedFileBase file)
        {
            List<SelectListItem> category = (from i in db.Categories.ToList()
                                             select new SelectListItem{
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.Category = category;

            

            var updatedObject = productRepository.GetById(p.Id);
            updatedObject.Name = p.Name;
            updatedObject.Description = p.Description;
            updatedObject.Price = p.Price;
            updatedObject.IsApproved = p.IsApproved;
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