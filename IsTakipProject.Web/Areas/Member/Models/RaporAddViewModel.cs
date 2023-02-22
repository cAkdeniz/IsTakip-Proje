using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web.Areas.Member.Models
{
    public class RaporAddViewModel
    {
        [Required(ErrorMessage ="Tanım alanı boş geçilemez.")]
        public string Tanim { get; set; }
        [Required(ErrorMessage = "Detay alanı boş geçilemez.")]
        public string Detay { get; set; }
        public int GorevId { get; set; }
        public Gorev Gorev { get; set; }
    }
}
