using System.ComponentModel.DataAnnotations;

namespace EmlakAlimSatim.Models
{
    public class Kullanicilar
    {
        [Key]
        public int KullaniciID { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        public string? KullaniciAdi { get; set; }
        [Required(ErrorMessage ="Adı Boş Bırakamazsınız")]
        public string Ad { get; set; } = string.Empty;
        [Required(ErrorMessage = "Soyadı Boş Bırakamazsınız")]
        public string Soyad { get; set; } = string.Empty;
        [Required(ErrorMessage = "Geçerli Bir E-mail Adresi Giriniz")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Şifreyi Boş Bırakamazsınız")]
        public string SifreHash { get; set; } = string.Empty;
        [Required(ErrorMessage = "Telefon Numarasını Boş Bırakamazsınız")]
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public DateTime  KayitTarihi { get; set; }
    }
}
