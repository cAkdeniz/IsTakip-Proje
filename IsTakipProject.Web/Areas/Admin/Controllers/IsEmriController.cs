using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using IsTakipProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class IsEmriController : Controller
    {
        private IAppUserService _appUserService;
        private IGorevService _gorevService;
        private UserManager<AppUser> _userManager;
        private IDosyaService _dosyaService;
        private IBildirimService _bildirimService;
        public IsEmriController(IAppUserService appUserService, IGorevService gorevService, UserManager<AppUser> userManager,
            IDosyaService dosyaService,IBildirimService bildirimService)
        {
            _bildirimService = bildirimService;
            _dosyaService = dosyaService;
            _userManager = userManager;
            _gorevService = gorevService;
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "isemri";

            List<Gorev> gorevler = _gorevService.GetirTumTablolarla();
            List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();

            foreach (var item in gorevler)
            {
                GorevListAllViewModel model = new GorevListAllViewModel();
                model.Id = item.Id;
                model.Ad = item.Ad;
                model.Aciklama = item.Aciklama;
                model.OlusturulmaTarihi = item.OlusturulmaTarihi;
                model.Aciliyet = item.Aciliyet;
                model.Raporlar = item.Raporlar;
                model.AppUser = item.AppUser;
                models.Add(model);
            }
            
            return View(models);
        }

        public IActionResult GetirExcel(int id)
        {
            var gorev = _gorevService.GetirRaporlarileAppUserbyId(id);

            return File(_dosyaService.AktarExcel(gorev.Raporlar),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetirPdf(int id)
        {
            var path = _dosyaService.AktarPdf(_gorevService.GetirRaporlarileAppUserbyId(id).Raporlar);

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }

        public IActionResult Detaylandir(int id)
        {
            TempData["active"] = "isemri";

            var gorev = _gorevService.GetirRaporlarileAppUserbyId(id);

            GorevListAllViewModel model = new GorevListAllViewModel();
            model.Id = gorev.Id;
            model.Aciklama = gorev.Aciklama;
            model.Ad = gorev.Ad;
            model.AppUser = gorev.AppUser;
            model.Raporlar = gorev.Raporlar;

            return View(model);
        }

        public IActionResult AtaPersonel(int id,string s,int aktifSayfa=1)
        {
            TempData["active"] = "isemri";

            ViewBag.AktifSayfa = aktifSayfa;
            int toplamSayfa;

            var gorev = _gorevService.GetirAciliyetileId(id);
            var personeller = _appUserService.GetirAdminOlmayanlar(out toplamSayfa, s, aktifSayfa);

            ViewBag.ArananKelime = s;
            ViewBag.ToplamSayfa = toplamSayfa;

            //ViewBag.ToplamSayfa = (int)Math.Ceiling((double)_appUserService.GetirAdminOlmayanlar().Count / 3);

            List<AppUserListViewModel> appUserListViewModels = new List<AppUserListViewModel>();

            foreach (var item in personeller)
            {
                AppUserListViewModel model = new AppUserListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Surname = item.Surname;
                model.Email = item.Email;
                model.Picture = item.Picture;
                appUserListViewModels.Add(model);
            }

            ViewBag.Personeller = appUserListViewModels;

            GorevListViewModel gorevModel = new GorevListViewModel();
            gorevModel.Id = gorev.Id;
            gorevModel.Ad = gorev.Ad;
            gorevModel.Aciklama = gorev.Aciklama;
            gorevModel.Aciliyet = gorev.Aciliyet;
            gorevModel.OlusturulmaTarihi = gorev.OlusturulmaTarihi;

            return View(gorevModel);
        }

        [HttpPost]
        public IActionResult AtaPersonel(GorevlendirPersonelViewModel model)
        {
            var guncellenecekGorev = _gorevService.GetirIdile(model.GorevId);
            guncellenecekGorev.AppUserId = model.AppUserId;
            _gorevService.Guncelle(guncellenecekGorev);

            _bildirimService.Kaydet(new Bildirim()
            {
                AppUserId = model.AppUserId,
                Aciklama = guncellenecekGorev.Ad + " adlı iş için görevlendirildiniz."
            });

            return RedirectToAction("Index");
        }

        public IActionResult GorevlendirPersonel(GorevlendirPersonelViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == model.AppUserId);
            var gorev = _gorevService.GetirAciliyetileId(model.GorevId);

            AppUserListViewModel userModel = new AppUserListViewModel();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.Surname = user.Surname;
            userModel.Email = user.Email;
            userModel.Picture = user.Picture;

            GorevListViewModel gorevModel = new GorevListViewModel();
            gorevModel.Id = gorev.Id;
            gorevModel.Ad = gorev.Ad;
            gorevModel.Aciklama = gorev.Aciklama;
            gorevModel.Aciliyet = gorev.Aciliyet;

            GorevlendirPersonelListViewModel gorevlendirPersonelmodel = new GorevlendirPersonelListViewModel();

            gorevlendirPersonelmodel.AppUser = userModel;
            gorevlendirPersonelmodel.Gorev = gorevModel;

            return View(gorevlendirPersonelmodel);
        }
    }
}