using IsTakipProject.Business.Interfaces;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.Concrete
{
    public class BildirimManager : IBildirimService
    {
        private IBildirimDal _bildirimDal;
        public BildirimManager(IBildirimDal bildirimDal)
        {
            _bildirimDal = bildirimDal;
        }

        public List<Bildirim> GetirHepsi()
        {
            return _bildirimDal.GetirHepsi();
        }

        public Bildirim GetirIdile(int id)
        {
            return _bildirimDal.GetirIdile(id);
        }

        public int GetirOkunmayanBildirimSayisi(int appUserId)
        {
            return _bildirimDal.GetirOkunmayanBildirimSayisi(appUserId);
        }

        public List<Bildirim> GetirOkunmayanlar(int appUserId)
        {
            return _bildirimDal.GetirOkunmayanlar(appUserId);
        }

        public void Guncelle(Bildirim tablo)
        {
            _bildirimDal.Guncelle(tablo);
        }

        public void Kaydet(Bildirim tablo)
        {
            _bildirimDal.Kaydet(tablo);
        }

        public void Sil(Bildirim tablo)
        {
            _bildirimDal.Sil(tablo);
        }
    }
}
