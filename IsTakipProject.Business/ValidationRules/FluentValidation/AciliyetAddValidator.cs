using FluentValidation;
using IsTakipProject.Entities.DTOs.AciliyetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.ValidationRules.FluentValidation
{
    public class AciliyetAddValidator: AbstractValidator<AciliyetAddDto>
    {
        public AciliyetAddValidator()
        {
            RuleFor(x => x.Tanim).NotEmpty().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
