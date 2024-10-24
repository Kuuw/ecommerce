using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class FeaturedProducts
    {
        public int Id { get; set; }

        [ForeignKey("Id")]
        public Product Product { get; set; }
    }
}
