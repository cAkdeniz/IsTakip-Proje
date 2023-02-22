using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web.Areas.Admin.Models
{
    public class GorevlendirPersonelListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }
        public GorevListViewModel Gorev { get; set; }
    }
}
