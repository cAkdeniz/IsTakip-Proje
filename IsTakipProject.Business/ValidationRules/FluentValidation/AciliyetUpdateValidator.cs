using FluentValidation;
using IsTakipProject.Entities.DTOs.AciliyetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.ValidationRules.FluentValidation
{
    class AciliyetUpdateValidator: AbstractValidator<AciliyetUpdateDto>
    {
        public AciliyetUpdateValidator()
        {
            RuleFor(x => x.Tanim).NotEmpty().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
