using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
    public class ProductStock
    {
        public int Id { get; set; }

        [ForeignKey("Id")]
        public virtual Product Product { get; set; }
        public int Stock {  get; set; }
    }
}