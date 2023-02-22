using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Contexts;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories
{
    public class EfGenericRepository<Tablo> : IGenericDal<Tablo>
        where Tablo : class, ITablo, new()
    {
        public List<Tablo> GetirHepsi()
        {
            using (var context = new IsTakipContext())
            {
                return context.Set<Tablo>().ToList();
            }
        }

        public Tablo GetirIdile(int id)
        {
            using (var context = new IsTakipContext())
            {
                return context.Set<Tablo>().Find(id);
            }
        }

        public void Guncelle(Tablo tablo)
        {
            using (var context = new IsTakipContext())
            {
                context.Entry(tablo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Kaydet(Tablo tablo)
        {
            using (var context = new IsTakipContext())
            {
                context.Entry(tablo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Sil(Tablo tablo)
        {
            using (var context = new IsTakipContext())
            {
                context.Entry(tablo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
