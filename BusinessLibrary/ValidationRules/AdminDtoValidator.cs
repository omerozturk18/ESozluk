using EntityLayer.Dtos;
using FluentValidation;

namespace BusinessLibrary.ValidationRules
{
    public class AdminDtoValidator : AbstractValidator<AdminDto>
    {
        public AdminDtoValidator()
        {
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Rol Boş Geçilemez");
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.AdminUserName).EmailAddress().WithMessage("Geçerli Mail Değil");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Yazar Şifresi Boş Geçilemez");
            RuleFor(x => x.AdminPassword).MinimumLength(6).WithMessage("Yazar Şifresi En Az 6 Karakter Olmalıdır");
        }
    }
}
