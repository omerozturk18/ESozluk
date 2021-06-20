using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
  public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçilemez");
            RuleFor(x => x.MessageContent).MinimumLength(35).WithMessage("Lüten en az 35 karakter giriniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lüten en az 3 karakter giriniz");
            RuleFor(x => x.ReceiverMail).MinimumLength(3).WithMessage("Lüten en az 3 karakter giriniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli Mail Değil");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lüten en fazla 100 karakter giriniz");

        }
    }
}
