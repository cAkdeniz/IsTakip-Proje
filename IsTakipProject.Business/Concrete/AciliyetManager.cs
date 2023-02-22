using IsTakipProject.Business.Interfaces;
using IsTakipProject.DataAccess.Concrete.EntityframeworkCore.Repositories;
using IsTakipProject.DataAccess.Interfaces;
using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.Concrete
{
    public class AciliyetManager : IAciliyetService
    {
        private IAciliyetDal _aciliyetDal;
        public AciliyetManager(IAciliyetDal aciliyetDal)
        {
            _aciliyetDal = aciliyetDal;
        }

        public List<Aciliyet> GetirHepsi()
        {
            return _aciliyetDal.GetirHepsi();
        }

        public Aciliyet GetirIdile(int id)
        {
            return _aciliyetDal.GetirIdile(id);
        }

        public void Guncelle(Aciliyet tablo)
        {
            _aciliyetDal.Guncelle(tablo);
        }

        public void Kaydet(Aciliyet tablo)
        {
            _aciliyetDal.Kaydet(tablo);
        }

        public void Sil(Aciliyet tablo)
        {
            _aciliyetDal.Sil(tablo);
        }
    }
}
