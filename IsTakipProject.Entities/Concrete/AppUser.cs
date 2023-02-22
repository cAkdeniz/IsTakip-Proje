using IsTakipProject.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Entities.Concrete
{
    public class AppUser: IdentityUser<int>, ITablo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Gorev> Gorevler { get; set; }
        public List<Bildirim> Bildirimler { get; set; }
    }
}
