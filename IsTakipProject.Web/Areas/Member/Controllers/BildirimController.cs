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
    public class BildirimController : Controller
    {
        private IBildirimService _bildirimService;
        private UserManager<AppUser> _userManager;
        public BildirimController(IBildirimService bildirimService, UserManager<AppUser> userManager)
        {
            _bildirimService = bildirimService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"] = "bildirim";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var bildirim = _bildirimService.GetirOkunmayanlar(user.Id);

            List<BildirimListViewModel> models = new List<BildirimListViewModel>();
            foreach (var item in bildirim)
            {
                BildirimListViewModel model = new BildirimListViewModel();
                model.Aciklama = item.Aciklama;
                model.Id = item.Id;
                models.Add(model);
            }

            return View(models);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var bildirim = _bildirimService.GetirIdile(id);
            bildirim.Durum = true;
            _bildirimService.Guncelle(bildirim);

            return RedirectToAction("Index");
        }
    }
}