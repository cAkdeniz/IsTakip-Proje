using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web.Areas.Admin.Models
{
    public class GorevListAllViewModel
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
