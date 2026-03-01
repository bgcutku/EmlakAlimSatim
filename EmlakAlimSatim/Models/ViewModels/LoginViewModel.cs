using System.ComponentModel.DataAnnotations;

namespace EmlakAlimSatim.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string KullaniciAdi { get; set; } = string.Empty;
        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string Sifre { get; set; } = string.Empty;
    }
}
