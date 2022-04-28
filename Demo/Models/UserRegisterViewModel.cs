using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UserRegisterViewModel
    {
        [Display(Name ="Ad Soyad")] //span alanında
        [Required(ErrorMessage ="Ad soyad alanı zorunludur.")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")] //span alanında
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password { get; set; }


        [Display(Name ="Tekrar Şifre")]
        [Compare("Password", ErrorMessage ="Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Eposta adresi")]
        [Required(ErrorMessage = "Eposta alanı zorunludur.")]
        public string Email { get; set; }


        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        public string Username { get; set; }



        public bool isTrue { get { return true; } }
        public bool IsTrue => true; //alternatif

        [Compare(nameof(isTrue), ErrorMessage ="Koşulları kabul etmek zorunludur.")]
        public bool CheckBox { get; set; }

       



    }
}
