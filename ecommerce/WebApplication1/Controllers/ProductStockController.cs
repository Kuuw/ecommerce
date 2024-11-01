using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductStockController : Controller
    {
        // GET: ProductStock
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public ActionResult Index(int page = 1)
        {
            ViewBag.stock = db.ProductStocks.ToList();
            return View(productRepository.List().ToPagedList(page, 3));
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
    }
}