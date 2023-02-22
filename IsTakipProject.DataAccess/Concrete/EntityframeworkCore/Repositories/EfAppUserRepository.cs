using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Contexts;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetirAdminOlmayanlar()
        {
            /*
            select * from AspNetUsers inner join AspNetUserRoles
            on AspNetUsers.Id=AspNetUserRoles.UserId
            inner join AspNetRoles
            on AspNetRoles.RoleId = AspNetRoles.Id where AspNetRoles.Name='Member'
            */
            using (var context = new IsTakipContext())
            {
                var result = from user in context.Users
                             join userRoles in context.UserRoles on user.Id equals userRoles.UserId
                             join roles in context.Roles on userRoles.RoleId equals roles.Id
                             where roles.Name == "Member"
                             select new AppUser()
                             {
                                 Id = user.Id,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 Picture = user.Picture,
                                 Email = user.Email,
                                 UserName = user.UserName
                             };
                return result.ToList();
            }
        }

        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa,string aranacakKelime, int aktifSayfa = 1)
        {
            using (var context = new IsTakipContext())
            {
                var result = from user in context.Users
                             join userRoles in context.UserRoles on user.Id equals userRoles.UserId
                             join roles in context.Roles on userRoles.RoleId equals roles.Id
                             where roles.Name == "Member"
                             select new AppUser()
                             {
                                 Id = user.Id,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 Picture = user.Picture,
                                 Email = user.Email,
                                 UserName = user.UserName
                             };

                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

                if (!string.IsNullOrWhiteSpace(aranacakKelime))
                {
                    result = result.Where(x => x.Name.ToLower().Contains(aranacakKelime.ToLower()) ||
                    x.Surname.ToLower().Contains(aranacakKelime.ToLower()));

                    toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);
                }

                result = result.Skip((aktifSayfa - 1) * 4).Take(4);

                return result.ToList();
            }
        }

        public List<DualHelper> GetirEnCokGorevTamamlamisPersoneller()
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Include(x => x.AppUser).Where(x => x.Durum).GroupBy(x => x.AppUser.UserName).
                    OrderByDescending(x => x.Count()).Take(5).Select(x => new DualHelper
                    {
                        Isim = x.Key,
                        GorevSayisi = x.Count()
                    }).ToList();
            }
        }

        public List<DualHelper> GetirEnCokGorevdeCalisanPersoneller()
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Include(x => x.AppUser).Where(x => !x.Durum && x.AppUserId!=null).
                    GroupBy(x => x.AppUser.UserName).OrderByDescending(x => x.Count()).Take(5).
                    Select(x => new DualHelper
                    {
                        Isim = x.Key,
                        GorevSayisi = x.Count()
                    }).ToList();
            }
        }
    }
}
