using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class PasswordChangeModel
    {
        [Required(ErrorMessage = "Lütfen eski şifrenizi girin.")]
        public string OldPass { get; set; }


        [Required(ErrorMessage = "Lütfen yeni şifrenizi girin.")]
        public string NewPass { get; set; }


        [Required(ErrorMessage ="Lütfen yeni şifrenizi tekrar girin.")]
        [Compare(nameof(NewPass), ErrorMessage ="Şifreleriniz uyuşmuyor.")]
        public string ConfirmNewPass { get; set; }
    }
}
