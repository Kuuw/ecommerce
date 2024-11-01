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
    public class AdminProductStockController : Controller
    {
        // GET: ProductStock
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public ActionResult Index(int page = 1)
        {
            return View(db.ProductStocks.ToList().ToPagedList(page, 3));
        }

        [HttpPost]
        public JsonResult Update(int productId, int updatedAmount)
        {
            try
            {
                var productToUpdate = db.ProductStocks.FirstOrDefault(x => x.Id == productId);

                if (productToUpdate != null)
                {
                    productToUpdate.Stock = updatedAmount;
                    db.SaveChanges();

                    return Json(new { success = true, message = "Stok başarıyla güncellendi." });
                }
                else
                {
                    return Json(new { success = false, message = "Ürün bulunamadı." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Hata: " + ex.Message });
            }
        }
    }
}