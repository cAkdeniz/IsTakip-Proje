using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web.Areas.Admin.Models
{
    public class AciliyetUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tanım Alanı Boş Geçilemez")]
        public string Tanim { get; set; }
    }
}
