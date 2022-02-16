using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ToDoValidator:AbstractValidator<ToDo>
    {
        public ToDoValidator()
        {
            RuleFor(a=> a.Job).NotEmpty().WithMessage("Lütfen burayı boş bırakmayın.");
        }
    }
}
