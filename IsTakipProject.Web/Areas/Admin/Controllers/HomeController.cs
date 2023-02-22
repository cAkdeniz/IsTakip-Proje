using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private UserManager<AppUser> _userManager;
        private IGorevService _gorevService;
        private IRaporService _raporService;
        private IBildirimService _bildirimService;
        public HomeController(IGorevService gorevService,IRaporService raporService, IBildirimService bildirimService,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _gorevService = gorevService;
            _raporService = raporService;
            _bildirimService = bildirimService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "anasayfa";
            var user = _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.AtanmayiBekleyenGorevSayisi = _gorevService.GetirAtanmayıBekleyen();
            ViewBag.TamamlanmisGorevSayisi = _gorevService.GetirTamamlanmisGorevSayisi();
            ViewBag.OkunmayanBildirimSayisi = _bildirimService.GetirOkunmayanBildirimSayisi(user.Id);
            ViewBag.RaporSayisi = _raporService.GetirToplamRaporSayisi();
            return View();
        }
    }
}