using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using IsTakipProject.Web.Areas.Admin.Models;
using IsTakipProject.Web.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace IsTakipProject.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class IsEmriController : Controller
    {
        private IGorevService _gorevService;
        private UserManager<AppUser> _userManager;
        private IRaporService _raporService;
        private IBildirimService _bildirimService;
        public IsEmriController(IGorevService gorevService, UserManager<AppUser> userManager, IRaporService raporService,
            IBildirimService bildirimService)
        {
            _bildirimService = bildirimService;
            _raporService = raporService;
            _gorevService = gorevService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"] = "isemri";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var gorevler = _gorevService.GetirTumTablolarla(x => x.AppUserId == user.Id && !x.Durum);
            List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();

            foreach (var gorev in gorevler)
            {
                GorevListAllViewModel model = new GorevListAllViewModel();
                model.Aciklama = gorev.Aciklama;
                model.Ad = gorev.Ad;
                model.Id = gorev.Id;
                model.Aciliyet = gorev.Aciliyet;
                //model.AppUser = gorev.AppUser;
                model.Raporlar = gorev.Raporlar;
                model.OlusturulmaTarihi = gorev.OlusturulmaTarihi;
                models.Add(model);
            }
            return View(models);
        }

        public IActionResult EkleRapor(int id)
        {
            TempData["active"] = "isemri";

            var gorev = _gorevService.GetirAciliyetileId(id);

            RaporAddViewModel model = new RaporAddViewModel();
            model.GorevId = id;
            model.Gorev = gorev;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EkleRapor(RaporAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _raporService.Kaydet(new Rapor()
                {
                    Tanim = model.Tanim,
                    Detay = model.Detay,
                    GorevId = model.GorevId
                });

                var aktifKullanici = await _userManager.FindByNameAsync(User.Identity.Name);

                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");

                foreach (var admin in adminUserList)
                {
                    _bildirimService.Kaydet(new Bildirim()
                    {
                        Aciklama = aktifKullanici.Name + " " + aktifKullanici.Surname + " yeni bir rapor yazdı.",
                        AppUserId = admin.Id,

                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult GuncelleRapor(int id)
        {
            TempData["active"] = "isemri";

            var rapor = _raporService.GetirGorevAciliyetileId(id);

            RaporUpdateViewModel model = new RaporUpdateViewModel();
            model.Id = rapor.Id;
            model.Tanim = rapor.Tanim;
            model.Detay = rapor.Detay;
            model.GorevId = rapor.GorevId;
            model.Gorev = rapor.Gorev;

            return View(model);
        }

        [HttpPost]
        public IActionResult GuncelleRapor(RaporUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekRapor = _raporService.GetirIdile(model.Id);

                guncellenecekRapor.Tanim = model.Tanim;
                guncellenecekRapor.Detay = model.Detay;

                _raporService.Guncelle(guncellenecekRapor);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Tamamlandi(int id)
        {
            var gorev = _gorevService.GetirIdile(id);
            gorev.Durum = true;
            _gorevService.Guncelle(gorev);

            var aktifKullanici = await _userManager.FindByNameAsync(User.Identity.Name);

            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");

            foreach (var admin in adminUserList)
            {
                _bildirimService.Kaydet(new Bildirim()
                {
                    Aciklama = aktifKullanici.Name + " " + aktifKullanici.Surname + " vermiş olduğunuz bir görevi" +
                    " tamamladı.",
                    AppUserId = admin.Id,

                });
            }

            return RedirectToAction("Index");
        }
    }
}