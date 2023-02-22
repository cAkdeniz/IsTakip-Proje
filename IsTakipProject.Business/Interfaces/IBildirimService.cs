using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.Interfaces
{
    public interface IBildirimService: IGenericService<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int appUserId);
        int GetirOkunmayanBildirimSayisi(int appUserId);
    }
}
