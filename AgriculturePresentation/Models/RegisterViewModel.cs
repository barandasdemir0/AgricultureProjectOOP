using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Lütfen mail Adınızı Giriniz")]
        public string? mail { get; set; }


        [Required(ErrorMessage = "Lütfen Password Giriniz")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "Lütfen Şifreyi tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu değil")]
        public string? ConfirmPassword { get; set; }

      
    }
}
