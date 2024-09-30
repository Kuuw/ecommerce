using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities
{
    public class Category
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

        public virtual List<Product> Products { get; set; }
    }
}
