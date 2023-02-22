using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.Interfaces
{
    public interface IRaporService: IGenericService<Rapor>
    {
        Rapor GetirGorevAciliyetileId(int id);
        int GetirRaporSayisiAppUserId(int appUserId);
        int GetirToplamRaporSayisi();
    }
}
