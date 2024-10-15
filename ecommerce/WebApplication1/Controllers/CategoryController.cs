using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public PartialViewResult CategoryList()
        {
            return PartialView(categoryRepository.List());
        }

        public ActionResult Details(int id)
        {
            var category = categoryRepository.CategoryDetails(id);
            return View(category);
        }
    }
}