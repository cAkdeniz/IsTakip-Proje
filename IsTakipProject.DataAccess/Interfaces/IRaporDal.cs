using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.DataAccess.Interfaces
{
    public interface IRaporDal: IGenericDal<Rapor>
    {
        Rapor GetirGorevAciliyetileId(int id);
        int GetirRaporSayisiAppUserId(int appUserId);
        int GetirToplamRaporSayisi();

    }
}
