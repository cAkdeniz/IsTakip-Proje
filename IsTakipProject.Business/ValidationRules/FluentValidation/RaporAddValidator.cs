using FluentValidation;
using IsTakipProject.Entities.DTOs.RaporDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.ValidationRules.FluentValidation
{
    public class RaporAddValidator: AbstractValidator<RaporAddDto>
    {
        public RaporAddValidator()
        {
            RuleFor(x => x.Tanim).NotEmpty().WithMessage("Tanım alanı boş geçilemez");
            RuleFor(x => x.Detay).NotEmpty().WithMessage("Detay alanı boş geçilemez");
        }
    }
}
