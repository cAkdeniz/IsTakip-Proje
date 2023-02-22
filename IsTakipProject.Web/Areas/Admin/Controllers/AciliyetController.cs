using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using IsTakipProject.Entities.DTOs.AciliyetDtos;
using IsTakipProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AciliyetController : Controller
    {
        private IAciliyetService _aciliyetService;
        private IMapper _mapper;
        public AciliyetController(IAciliyetService aciliyetService,IMapper mapper)
        {
            _mapper = mapper;
            _aciliyetService = aciliyetService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "aciliyet";

            /*List<AciliyetListViewModel> models = new List<AciliyetListViewModel>();

            foreach (var item in aciliyetler)
            {
                AciliyetListViewModel model = new AciliyetListViewModel();
                model.Id = item.Id;
                model.Tanim = item.Tanim;

                models.Add(model);
            }*/

            return View(_mapper.Map<List<AciliyetListDto>>(_aciliyetService.GetirHepsi()));
        }
        public IActionResult EkleAciliyet()
        {
            TempData["active"] = "aciliyet";
            return View(new AciliyetAddViewModel());
        }

        [HttpPost]
        public IActionResult EkleAciliyet(AciliyetAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Kaydet(new Aciliyet()
                {
                    Tanim = model.Tanim
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult GuncelleAciliyet(int id)
        {
            TempData["active"] = "aciliyet";
            var aciliyet = _aciliyetService.GetirIdile(id);

            AciliyetUpdateViewModel model = new AciliyetUpdateViewModel
            {
                Id = aciliyet.Id,
                Tanim = aciliyet.Tanim
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult GuncelleAciliyet(AciliyetUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Guncelle(new Aciliyet()
                {
                    Id = model.Id,
                    Tanim = model.Tanim
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}