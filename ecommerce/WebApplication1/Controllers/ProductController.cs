using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        FeaturedProductRepository featuredProductRepository = new FeaturedProductRepository();
        DataContext db = new DataContext();
        public PartialViewResult FeaturedProduct()
        {
            List<Product> featuredProduct = featuredProductRepository.GetFeaturedProduct();
            ViewBag.featured = featuredProduct;
            return PartialView(featuredProduct);
        }

        public ActionResult Details(int id)
        {
            var product = productRepository.GetById(id);
            var comment = db.Comment.Where(x => x.ProductId == id).ToList();
            ViewBag.comment = comment;
            return View(product);
        }

        public ActionResult Comment(Comment data) 
        {
            if (User.Identity.IsAuthenticated) 
            {
                db.Comment.Add(data);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Product", action = "Details", Id = data.ProductId }));
        }
    }
}