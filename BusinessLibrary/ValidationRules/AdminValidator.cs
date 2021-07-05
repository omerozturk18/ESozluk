using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {

            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Rol Boş Geçilemez");
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.AdminUserName).EmailAddress().WithMessage("Geçerli Mail Değil");
        }
    }
}
