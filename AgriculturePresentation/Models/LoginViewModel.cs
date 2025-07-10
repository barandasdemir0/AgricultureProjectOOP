using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı adını giriniz")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi giriniz")]
        public string? Password { get; set; }
    }
}
