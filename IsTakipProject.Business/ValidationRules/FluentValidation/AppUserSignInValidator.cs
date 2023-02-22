using FluentValidation;
using IsTakipProject.Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator: AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");

        }
    }
}
