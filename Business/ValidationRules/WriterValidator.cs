using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().WithMessage("Ad kısmı boş bırakılamaz.");
            RuleFor(a => a.FirstName).MinimumLength(2).WithMessage("Geçersiz isim.");
            RuleFor(a => a.FirstName).MaximumLength(50).WithMessage("Karakter sınırı aşıldı.");

            RuleFor(a => a.LastName).NotEmpty().WithMessage("Soyad kısmı boş bırakılamaz.");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Mail kısmı boş bırakılamaz.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Şifre kısmı boş bırakılamaz.");
            //password 1 büyük 1 küçük ve 1 sayı karakter içermeli ÖDEV
        }
    }
}
