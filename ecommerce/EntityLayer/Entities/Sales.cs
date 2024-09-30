using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        [Display(Name = "Ürün")]
        public int ProductId { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
        [Display(Name = "Görsel")]
        public string Image { get; set; }
        [Display(Name = "Kullanıcı")]
        public int UserId { get; set; }
    }
}
