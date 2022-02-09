using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ArticleValidator:AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(a=> a.Title).NotEmpty().WithMessage("Makale başlığı boş geçilemez.");
            RuleFor(a => a.Content).NotEmpty().WithMessage("İçerik boş olamaz");
            RuleFor(a => a.Image).NotEmpty().WithMessage("Görsel boş olamaz");
            RuleFor(a => a.Title).MaximumLength(150).WithMessage("150 Karakterden fazla girilemez.");
            RuleFor(a => a.Title).MinimumLength(4).WithMessage("4 Karakterden az girilemez.");

        }
    }
}
