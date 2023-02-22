using FluentValidation;
using IsTakipProject.Business.Concrete;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Business.ValidationRules.FluentValidation;
using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.DTOs.AciliyetDtos;
using IsTakipProject.Entities.DTOs.AppUserDtos;
using IsTakipProject.Entities.DTOs.GorevDtos;
using IsTakipProject.Entities.DTOs.RaporDtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace IsTakipProject.Business.Extensions
{
    public static class CustomExtension
    {
        public static void AddContainerWithDependeny(this IServiceCollection services)
        {
            services.AddScoped<IGorevService, GorevManager>();
            services.AddScoped<IAciliyetService, AciliyetManager>();
            services.AddScoped<IRaporService, RaporManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IDosyaService, DosyaManager>();
            services.AddScoped<IBildirimService, BildirimManager>();

            services.AddScoped<IGorevDal, EfGorevRepository>();
            services.AddScoped<IAciliyetDal, EfAciliyetRepository>();
            services.AddScoped<IRaporDal, EfRaporRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IBildirimDal, EfBildirimRepository>();
        }

        public static void AddValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AciliyetAddDto>, AciliyetAddValidator>();
            services.AddTransient<IValidator<AciliyetUpdateDto>, AciliyetUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<GorevAddDto>, GorevAddValidator>();
            services.AddTransient<IValidator<GorevUpdateDto>, GorevUpdateValidator>();
            services.AddTransient<IValidator<RaporAddDto>, RaporAddValidator>();
            services.AddTransient<IValidator<RaporUpdateDto>, RaporUpdateValidator>();
        }
    }
}
