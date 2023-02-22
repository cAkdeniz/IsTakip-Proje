using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using IsTakipProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsTakipProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GorevController : Controller
    {
        private IGorevService _gorevService;
        private IAciliyetService _aciliyetService;
        public GorevController(IGorevService gorevService,IAciliyetService aciliyetService)
        {
            _aciliyetService = aciliyetService;
            _gorevService = gorevService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "gorev";
            List<Gorev> gorevler = _gorevService.GetirAciliyetIleTamamlanmayan();

            List<GorevListViewModel> models = new List<GorevListViewModel>();

            foreach (var item in gorevler)
            {
                GorevListViewModel model = new GorevListViewModel();
                model.Id = item.Id;
                model.AciliyetId = item.AciliyetId;
                model.Aciliyet = item.Aciliyet;
                model.Aciklama = item.Aciklama;
                model.Ad = item.Ad;
                model.Durum = item.Durum;
                model.OlusturulmaTarihi = item.OlusturulmaTarihi;
                
                models.Add(model);
            }

            return View(models);
        }

        public IActionResult TamamlanmisGorevler(int aktifSayfa=1)
        {
            TempData["active"] = "gorev";

            int toplamSayfa;

            var gorevler = _gorevService.GetirTamamlanmisGorevlerTumTablolarla(out toplamSayfa,aktifSayfa);

            ViewBag.AktifSayfa = aktifSayfa;
            ViewBag.ToplamSayfa = toplamSayfa;

            List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();

            foreach (var gorev in gorevler)
            {
                GorevListAllViewModel model = new GorevListAllViewModel();
                model.Aciklama = gorev.Aciklama;
                model.Ad = gorev.Ad;
                model.Id = gorev.Id;
                model.Aciliyet = gorev.Aciliyet;
                model.AppUser = gorev.AppUser;
                model.Raporlar = gorev.Raporlar;
                model.OlusturulmaTarihi = gorev.OlusturulmaTarihi;
                models.Add(model);
            }

            return View(models);
        }

        public IActionResult EkleGorev()
        {
            TempData["active"] = "gorev";

            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            return View(new GorevAddViewModel());
        }

        [HttpPost]
        public IActionResult EkleGorev(GorevAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _gorevService.Kaydet(new Gorev()
                {
                    Ad = model.Ad,
                    Aciklama = model.Aciklama,
                    AciliyetId = model.AciliyetId
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult GuncelleGorev(int id)
        {
            TempData["active"] = "gorev";
            var gorev = _gorevService.GetirIdile(id);

            GorevUpdateViewModel model = new GorevUpdateViewModel
            {
                Id = gorev.Id,
                Ad = gorev.Ad,
                Aciklama = gorev.Aciklama,
                AciliyetId = gorev.AciliyetId
            };

            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", gorev.AciliyetId);

            return View(model);
        }

        [HttpPost]
        public IActionResult GuncelleGorev(GorevUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _gorevService.Guncelle(new Gorev()
                {
                    Id = model.Id,
                    Ad = model.Ad,
                    Aciklama = model.Aciklama,
                    AciliyetId = model.AciliyetId
                });
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult SilGorev(int id)
        {
            _gorevService.Sil(new Gorev()
            {
                Id = id
            });

            return RedirectToAction("Index");
        }
    }
}