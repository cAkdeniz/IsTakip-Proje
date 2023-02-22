using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Contexts;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories
{
    public class EfBildirimRepository : EfGenericRepository<Bildirim>, IBildirimDal
    {
        public int GetirOkunmayanBildirimSayisi(int appUserId)
        {
            using (var context = new IsTakipContext())
            {
                return context.Bildirimler.Where(x => x.AppUserId == appUserId && !x.Durum).Count();
            }
        }

        public List<Bildirim> GetirOkunmayanlar(int appUserId)
        {
            using (var context = new IsTakipContext())
            {
                return context.Bildirimler.Where(x => x.AppUserId == appUserId && !x.Durum).ToList();
            }
        }
    }
}
