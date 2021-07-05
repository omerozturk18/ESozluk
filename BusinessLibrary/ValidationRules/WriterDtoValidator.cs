using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
    public class WriterDtoValidator : AbstractValidator<WriterDto>
    {
        public WriterDtoValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lüten en az 2 karakter giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karakter olmalı");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli Mail Değil");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanı Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar Şifresi Boş Geçilemez");
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Yazar Şifresi En Az 6 Karakter Olmalıdır");
            RuleFor(x => x.WriterVerifyPassword).NotEmpty().WithMessage("Yazar Şifresi Boş Geçilemez");
            RuleFor(x => x.WriterVerifyPassword).MinimumLength(6).WithMessage("Yazar Şifresi En Az 6 Karakter Olmalıdır");


        }
       
    }
}
