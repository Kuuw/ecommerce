using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        public ActionResult Index()
        {
            return View(productRepository.List());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                productRepository.Insert(p);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var objectToDelete = productRepository.GetById(id);
            productRepository.Delete(objectToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var objectToUpdate = productRepository.GetById(id);
            return View(objectToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product p)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir hata oluştu.");
                return View();
            }
            var updatedObject = productRepository.GetById(p.Id);
            updatedObject.Name = p.Name;
            updatedObject.Description = p.Description;
            updatedObject.Stock = p.Stock;
            updatedObject.Price = p.Price;
            updatedObject.isApproved = p.isApproved;
            updatedObject.Popular = p.Popular;
            updatedObject.Category = p.Category;
            updatedObject.CatergoryId = p.CatergoryId;

            productRepository.Update(updatedObject);
            return RedirectToAction("Index");
        }
    }
}