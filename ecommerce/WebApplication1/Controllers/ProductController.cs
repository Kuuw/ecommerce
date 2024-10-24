using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        public PartialViewResult FeaturedProduct()
        {
            List<Product> featuredProduct = productRepository.GetFeaturedProduct();
            ViewBag.featured = featuredProduct;
            return PartialView(featuredProduct);
        }

        public ActionResult Details(int id)
        {
            var product = productRepository.GetById(id);
            return View(product);
        }
    }
}