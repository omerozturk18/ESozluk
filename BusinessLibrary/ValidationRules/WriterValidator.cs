using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lüten en az 2 karakter giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karakter olmalı");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Boş Geçilemez");
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Metin A Harfi İçermelidir");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli Mail Değil");

        }
        private bool IsAboutValid(string arg)
        {
            return arg.Contains("a");
        }
    }
}
