using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Entities.DTOs.AciliyetDtos
{
    public class AciliyetUpdateDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Tanım Alanı Boş Geçilemez")]
        public string Tanim { get; set; }
    }
}
