using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            return View(categoryRepository.List());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category p)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Insert(p);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var objectToDelete = categoryRepository.GetById(id);
            categoryRepository.Delete(objectToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var objectToUpdate = categoryRepository.GetById(id);
            return View(objectToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Category p)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir hata oluştu.");
                return View();
            }
            var updatedObject = categoryRepository.GetById(p.Id);
            updatedObject.Name = p.Name;
            updatedObject.Description = p.Description;
            categoryRepository.Update(updatedObject);
            return RedirectToAction("Index");
        }
    }
}