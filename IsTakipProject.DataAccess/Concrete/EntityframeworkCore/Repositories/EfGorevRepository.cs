using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Contexts;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories
{
    public class EfGorevRepository : EfGenericRepository<Gorev>, IGorevDal
    {
        public Gorev GetirAciliyetileId(int id)
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Include(x => x.Aciliyet).FirstOrDefault(x => !x.Durum
                && x.Id == id);
            }
        }

        public List<Gorev> GetirAciliyetIleTamamlanmayan()
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Include(x => x.Aciliyet).Where(x => !x.Durum)
                    .OrderByDescending(x => x.OlusturulmaTarihi).ToList();
            }
        }

        public int GetirAtanmayıBekleyen()
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Where(x=>x.AppUserId==null && !x.Durum).Count();
            }
        }

        public List<Gorev> GetirileAppUserId(int appUserId)
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Where(x => x.AppUserId == appUserId).ToList();
            }
        }

        public Gorev GetirRaporlarileAppUserbyId(int id)
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Include(x => x.Raporlar).Include(x => x.AppUser)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public int GetirTamamlananGorevSayisiAppUserId(int appUserId)
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Where(x => x.AppUserId == appUserId && x.Durum).Count();
            }
        }

        public int GetirTamamlanmayanGorevSayisiAppUserId(int appUserId)
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Where(x => x.AppUserId == appUserId && !x.Durum).Count();
            }
        }

        public int GetirTamamlanmisGorevSayisi()
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Where(x => x.Durum).Count();
            }
        }

        public List<Gorev> GetirTumTablolarla()
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Include(x => x.Aciliyet).Include(x=>x.Raporlar)
                    .Include(x=>x.AppUser).Where(x => !x.Durum).ToList();
            }
        }     

        public List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter)
        {
            using (var context = new IsTakipContext())
            {
                return context.Gorevler.Include(x => x.Aciliyet).Include(x => x.Raporlar)
                    .Include(x => x.AppUser).Where(filter).ToList();
            }
        }

        public List<Gorev> GetirTumTablolarlaTamamlanan(out int toplamSayfa, int appUserId, int aktifSayfa = 1)
        {
            using (var context = new IsTakipContext())
            {
                var result = context.Gorevler.Include(x => x.Aciliyet).Include(x => x.Raporlar)
                    .Include(x => x.AppUser).Where(x=>x.AppUserId==appUserId && x.Durum);

                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

                return result.Skip((aktifSayfa - 1) * 4).Take(4).ToList();
            }
        }
        public List<Gorev> GetirTamamlanmisGorevlerTumTablolarla(out int toplamSayfa, int aktifSayfa = 1)
        {
            using (var context = new IsTakipContext())
            {
                var result = context.Gorevler.Include(x => x.Aciliyet).Include(x => x.Raporlar)
                    .Include(x => x.AppUser).Where(x => x.Durum).ToList();

                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

                return result.Skip((aktifSayfa - 1) * 6).Take(6).ToList();
            }
        }

    }
}
