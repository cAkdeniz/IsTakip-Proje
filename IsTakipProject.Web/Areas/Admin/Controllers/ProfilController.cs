using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Entities.Concrete;
using IsTakipProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IsTakipProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ProfilController : Controller
    {
        private UserManager<AppUser> _userManager;
        public ProfilController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"] = "profil";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = user.Id;
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.PhoneNumber = user.PhoneNumber;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekUser = _userManager.Users.FirstOrDefault(x=>x.Id==model.Id);

                guncellenecekUser.Name = model.Name;
                guncellenecekUser.Surname = model.Surname;
                guncellenecekUser.Email = model.Email;
                guncellenecekUser.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.UpdateAsync(guncellenecekUser);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işlemi başarı bir şekilde gerçekleşti";
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}