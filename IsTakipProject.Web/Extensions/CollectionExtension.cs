using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Contexts;
using IsTakipProject.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web.Extensions
{
    public static class CollectionExtension
    {
        public static void AddIdentityConfigure(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 1;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<IsTakipContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }
    }
}
