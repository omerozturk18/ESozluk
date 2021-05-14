using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adı Boş Geçilemez");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Boş Geçilemez");
            RuleFor(x => x.HeadingName).MinimumLength(2).WithMessage("Lüten en az 3 karakter giriniz");
        }
    }
}
