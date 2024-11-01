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
        public new List<Product> List()
        { 
            return db.Products.Where(x=> x.IsApproved == true).ToList();
        }

        public List<Product> AdminList()
        {
            return db.Products.ToList();
        }
    }
}
