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
        public PartialViewResult PopularProduct()
        {
            List<Product> popularProduct = productRepository.GetPopularProduct();
            ViewBag.popular = popularProduct;
            return PartialView(popularProduct);
        }
    }
}