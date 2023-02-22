using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Entities.DTOs.RaporDtos
{
    public class RaporAddDto
    {
        //[Required(ErrorMessage = "Tanım alanı boş geçilemez.")]
        public string Tanim { get; set; }
        //[Required(ErrorMessage = "Detay alanı boş geçilemez.")]
        public string Detay { get; set; }
        public int GorevId { get; set; }
        public Gorev Gorev { get; set; }
    }
}
