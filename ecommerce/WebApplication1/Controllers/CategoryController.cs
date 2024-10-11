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

        public PartialViewResult Details()
        {
            return PartialView(categoryRepository.List());
        }
    }
}