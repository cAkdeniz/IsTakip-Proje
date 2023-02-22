using IsTakipProject.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Entities.Concrete
{
    public class AppRole: IdentityRole<int>, ITablo
    {
    }
}
