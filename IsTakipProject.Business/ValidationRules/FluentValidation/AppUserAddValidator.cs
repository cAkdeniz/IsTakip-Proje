using FluentValidation;
using IsTakipProject.Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator: AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Parola onay alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez")
                .EmailAddress().WithMessage("Lütfen geçerli bir email adresi girin");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad adı alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
        }
    }
}
