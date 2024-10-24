using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "E-posta")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "E-posta formatını kontrol ediniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [Display(Name = "Şifre")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
