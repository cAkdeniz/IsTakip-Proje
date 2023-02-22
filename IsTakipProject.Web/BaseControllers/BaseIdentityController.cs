using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipProject.Web.BaseControllers
{
    public class BaseIdentityController : Controller
    {
        protected UserManager<AppUser> _userManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<AppUser> GetirGirisYapanKullanici()
        {
            return await _userManager.FindByNameAsync(User.Identity.Name);
        }
    }
}