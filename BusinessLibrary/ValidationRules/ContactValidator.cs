﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
  public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu  Boş Geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lüten en az 3 karakter giriniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lüten en az 3 karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lüten en fazla 50 karakter giriniz");

        }
    }
}
