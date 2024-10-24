using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter olmalıdır.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Ücret")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Onaylı")]
        public bool isApproved { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Görsel")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Adet")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
