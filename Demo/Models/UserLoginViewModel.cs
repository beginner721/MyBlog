using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş olamaz.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Şifre boş olamaz.")]
        public string Password { get; set; }

    }
}
