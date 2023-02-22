using IsTakipProject.Business.Interfaces;
using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IsTakipProject.Business.Concrete
{
    public class GorevManager: IGorevService
    {
        private IGorevDal _gorevDal;
        public GorevManager(IGorevDal gorevDal)
        {
            _gorevDal = gorevDal;
        }

        public Gorev GetirAciliyetileId(int id)
        {
            return _gorevDal.GetirAciliyetileId(id);
        }

        public List<Gorev> GetirAciliyetIleTamamlanmayan()
        {
            return _gorevDal.GetirAciliyetIleTamamlanmayan();
        }

        public int GetirAtanmayıBekleyen()
        {
            return _gorevDal.GetirAtanmayıBekleyen();
        }

        public List<Gorev> GetirHepsi()
        {
            return _gorevDal.GetirHepsi();
        }

        public Gorev GetirIdile(int id)
        {
            return _gorevDal.GetirIdile(id);
        }

        public List<Gorev> GetirileAppUserId(int appUserId)
        {
            return _gorevDal.GetirileAppUserId(appUserId);
        }

        public Gorev GetirRaporlarileAppUserbyId(int id)
        {
            return _gorevDal.GetirRaporlarileAppUserbyId(id);
        }

        public int GetirTamamlananGorevSayisiAppUserId(int appUserId)
        {
            return _gorevDal.GetirTamamlananGorevSayisiAppUserId(appUserId);
        }

        public int GetirTamamlanmayanGorevSayisiAppUserId(int appUserId)
        {
            return _gorevDal.GetirTamamlanmayanGorevSayisiAppUserId(appUserId);
        }

        public List<Gorev> GetirTamamlanmisGorevlerTumTablolarla(out int toplamSayfa, int aktifSayfa)
        {
            return _gorevDal.GetirTamamlanmisGorevlerTumTablolarla(out toplamSayfa, aktifSayfa);
        }

        public int GetirTamamlanmisGorevSayisi()
        {
            return _gorevDal.GetirTamamlanmisGorevSayisi();
        }

        public List<Gorev> GetirTumTablolarla()
        {
            return _gorevDal.GetirTumTablolarla();
        }

        public List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter)
        {
            return _gorevDal.GetirTumTablolarla(filter);
        }

        public List<Gorev> GetirTumTablolarlaTamamlanan(out int toplamSayfa, int appUserId, int aktifSayfa)
        {
            return _gorevDal.GetirTumTablolarlaTamamlanan(out toplamSayfa, appUserId, aktifSayfa);
        }

        public void Guncelle(Gorev tablo)
        {
            _gorevDal.Guncelle(tablo);
        }

        public void Kaydet(Gorev tablo)
        {
            _gorevDal.Kaydet(tablo);
        }

        public void Sil(Gorev tablo)
        {
            _gorevDal.Sil(tablo);
        }
    }
}
