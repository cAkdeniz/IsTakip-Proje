using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using IsTakipProject.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private IGorevService _gorevService;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public HomeController(IGorevService gorevService,UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _gorevService = gorevService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(AppUserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (identityResult.Succeeded)
                    {
                        var rol = await _userManager.GetRolesAsync(user);
                        if (rol.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı!");
            }
            return View("Index", model);
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(AppUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email
                };
                var userResult = await _userManager.CreateAsync(user, model.Password);

                if (userResult.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Member");

                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CikisYap()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}