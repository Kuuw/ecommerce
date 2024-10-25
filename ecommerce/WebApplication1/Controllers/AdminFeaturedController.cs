using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using EntityLayer.Entities;

namespace WebApplication1.Controllers
{
    public class AdminFeaturedController : Controller
    {
        FeaturedProductRepository FeaturedProductRepository = new FeaturedProductRepository();
        DataContext db = new DataContext();
        public ActionResult Index(int page = 1)
        {
            return View(FeaturedProductRepository.GetFeaturedProduct().ToPagedList(page, 5));
        }

        public ActionResult Delete(int id)
        {
            FeaturedProducts fp = FeaturedProductRepository.GetById(id);
            FeaturedProductRepository.Delete(fp);
            return RedirectToAction("Index", "AdminFeatured");
        }

        public ActionResult Create(int id)
        {
            FeaturedProducts fp = new FeaturedProducts();
            fp.Id = id;
            FeaturedProductRepository.Insert(fp);
            return RedirectToAction("Index", "AdminFeatured");
        }
    }
}