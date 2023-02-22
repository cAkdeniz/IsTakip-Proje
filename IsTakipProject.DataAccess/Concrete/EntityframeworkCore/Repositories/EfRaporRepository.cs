using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Contexts;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories
{
    public class EfRaporRepository : EfGenericRepository<Rapor>, IRaporDal
    {
        public Rapor GetirGorevAciliyetileId(int id)
        {
            using (var context = new IsTakipContext())
            {
                return context.Raporlar.Include(x => x.Gorev).ThenInclude(x => x.Aciliyet)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public int GetirRaporSayisiAppUserId(int appUserId)
        {
            using (var context = new IsTakipContext())
            {
                var result = context.Gorevler.Include(x => x.Raporlar).Where(x => x.AppUserId == appUserId);

                return result.SelectMany(x => x.Raporlar).Count();
            }
        }

        public int GetirToplamRaporSayisi()
        {
            using (var context = new IsTakipContext())
            {
                return context.Raporlar.Count();
            }
        }
    }
}
