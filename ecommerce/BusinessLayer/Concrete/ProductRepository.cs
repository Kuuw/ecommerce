using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductRepository : GenericRepository<Product>
    {
        DataContext db = new DataContext();
        public List<Product> GetFeaturedProduct()
        {
            return db.FeaturedProducts
                .Include("Product") 
                .Select(fp => fp.Product)
                .ToList();
        }
    }
}
