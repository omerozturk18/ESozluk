using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lüten en az 3 karakter giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("En fazla 20 karakter olmalı");

        }
    }
}
