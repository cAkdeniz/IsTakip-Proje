using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Entities.DTOs.GorevDtos
{
    public class GorevAddDto
    {
        //[Required(ErrorMessage = "Ad Alanı Boş Geçilemez.")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }

        //[Range(0, int.MaxValue, ErrorMessage = "Lütfen Aciliyet Durumunu Seçiniz")]
        public int AciliyetId { get; set; }
    }
}
