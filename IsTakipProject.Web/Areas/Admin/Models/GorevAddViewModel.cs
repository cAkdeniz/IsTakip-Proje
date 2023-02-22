using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web.Areas.Admin.Models
{
    public class GorevAddViewModel
    {
        [Required(ErrorMessage ="Ad Alanı Boş Geçilemez.")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        
        [Range(0,int.MaxValue,ErrorMessage ="Lütfen Aciliyet Durumunu Seçiniz")]
        public int AciliyetId { get; set; }
    }
}
