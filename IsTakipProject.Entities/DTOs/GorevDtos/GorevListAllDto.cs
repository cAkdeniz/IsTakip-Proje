﻿using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Entities.DTOs.GorevDtos
{
    public class GorevListAllDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

        public Aciliyet Aciliyet { get; set; }

        public List<Rapor> Raporlar { get; set; }

        public AppUser AppUser { get; set; }
    }
}
