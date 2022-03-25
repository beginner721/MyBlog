using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(a=> a.Name).NotEmpty().WithMessage("Kategori adı boş olamaz.");
            RuleFor(a=> a.Name).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır.");
            RuleFor(a=> a.Name).MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır.");
            RuleFor(a=> a.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
        }
    }
}
