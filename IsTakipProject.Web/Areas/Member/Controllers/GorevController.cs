using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using IsTakipProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipProject.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class GorevController : Controller
    {
        private IGorevService _gorevService;
        private UserManager<AppUser> _userManager;
        public GorevController(IGorevService gorevService, UserManager<AppUser> userManager)
        {
            _gorevService = gorevService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int aktifSayfa=1)
        {
            TempData["active"] = "gorev";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            int toplamSayfa;

            var gorevler = _gorevService.GetirTumTablolarlaTamamlanan(out toplamSayfa,user.Id,aktifSayfa);

            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.AktifSayfa = aktifSayfa;

            List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();

            foreach (var gorev in gorevler)
            {
                GorevListAllViewModel model = new GorevListAllViewModel();
                model.Id = gorev.Id;
                model.Ad = gorev.Ad;
                model.Aciklama = gorev.Aciklama;
                model.OlusturulmaTarihi = gorev.OlusturulmaTarihi;
                model.Aciliyet = gorev.Aciliyet;
                //model.AppUser = gorev.AppUser;
                model.Raporlar = gorev.Raporlar;
                models.Add(model);
            }

            return View(models);
        }
    }
}