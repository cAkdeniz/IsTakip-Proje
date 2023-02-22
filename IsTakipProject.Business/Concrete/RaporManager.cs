using IsTakipProject.Business.Interfaces;
using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.Concrete
{
    public class RaporManager : IRaporService
    {
        private IRaporDal _raporDal;
        public RaporManager(IRaporDal raporDal)
        {
            _raporDal = raporDal;
        }

        public Rapor GetirGorevAciliyetileId(int id)
        {
            return _raporDal.GetirGorevAciliyetileId(id);
        }

        public List<Rapor> GetirHepsi()
        {
            return _raporDal.GetirHepsi();
        }

        public Rapor GetirIdile(int id)
        {
            return _raporDal.GetirIdile(id);
        }

        public int GetirRaporSayisiAppUserId(int appUserId)
        {
            return _raporDal.GetirRaporSayisiAppUserId(appUserId);
        }

        public int GetirToplamRaporSayisi()
        {
            return _raporDal.GetirToplamRaporSayisi();
        }

        public void Guncelle(Rapor tablo)
        {
            _raporDal.Guncelle(tablo);
        }

        public void Kaydet(Rapor tablo)
        {
            _raporDal.Kaydet(tablo);
        }

        public void Sil(Rapor tablo)
        {
            _raporDal.Sil(tablo);
        }
    }
}
