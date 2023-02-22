using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipProject.Web.Areas.Member.Controllers
{
    [Authorize(Roles ="Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        private UserManager<AppUser> _userManager;
        private IRaporService _raporService;
        private IGorevService _gorevService;
        private IBildirimService _bildirimService;
        public HomeController(UserManager<AppUser> userManager,IRaporService raporService,IGorevService gorevService
            ,IBildirimService bildirimService)
        {
            _bildirimService = bildirimService;
            _userManager = userManager;
            _raporService = raporService;
            _gorevService = gorevService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"] = "anasayfa";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.RaporSayisi = _raporService.GetirRaporSayisiAppUserId(user.Id);
            ViewBag.TamamlananGorevSayisi = _gorevService.GetirTamamlananGorevSayisiAppUserId(user.Id);
            ViewBag.TamamlanmayanGorevSayisi = _gorevService.GetirTamamlanmayanGorevSayisiAppUserId(user.Id);
            ViewBag.OkunmayanBildirimSayisi = _bildirimService.GetirOkunmayanBildirimSayisi(user.Id);
            return View();
        }
    }
}