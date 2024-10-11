using BusinessLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        public ActionResult Index(int page = 1)
        {
            return View(productRepository.List().ToPagedList(page, 3));
        }
    }
}