using FluentValidation;
using IsTakipProject.Entities.DTOs.GorevDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.ValidationRules.FluentValidation
{
    public class GorevUpdateValidator: AbstractValidator<GorevUpdateDto>
    {
        public GorevUpdateValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.AciliyetId).ExclusiveBetween(1, int.MaxValue).WithMessage("Lütfen aciliyet durumu seçiniz");
        }
    }
}
