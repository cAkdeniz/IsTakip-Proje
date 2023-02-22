using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.DataAccess.Interfaces
{
    public interface IBildirimDal: IGenericDal<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int appUserId);
        int GetirOkunmayanBildirimSayisi(int appUserId);
    }
}
