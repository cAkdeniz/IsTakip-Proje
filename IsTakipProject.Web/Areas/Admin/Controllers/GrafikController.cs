using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipProject.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IsTakipProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class GrafikController : Controller
    {
        private IAppUserService _userService;
        public GrafikController(IAppUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "grafik";
            return View();
        }

        public IActionResult EnCokTamamlayan()
        {
            var jsonString = JsonConvert.SerializeObject(_userService.GetirEnCokGorevTamamlamisPersoneller());
            return Json(jsonString);
        }
        public IActionResult EnCokCalisan()
        {
            var jsonString = JsonConvert.SerializeObject(_userService.GetirEnCokGorevdeCalisanPersoneller());
            return Json(jsonString);

        }
    }
}