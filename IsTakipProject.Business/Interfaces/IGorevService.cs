using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IsTakipProject.Business.Interfaces
{
    public interface IGorevService: IGenericService<Gorev>
    {
        List<Gorev> GetirAciliyetIleTamamlanmayan();
        List<Gorev> GetirTumTablolarla();
        List<Gorev> GetirTumTablolarlaTamamlanan(out int toplamSayfa, int appUserId, int aktifSayfa);
        List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter);
        Gorev GetirAciliyetileId(int id);
        List<Gorev> GetirileAppUserId(int appUserId);
        List<Gorev> GetirTamamlanmisGorevlerTumTablolarla(out int toplamSayfa, int aktifSayfa);
        Gorev GetirRaporlarileAppUserbyId(int id);
        int GetirTamamlananGorevSayisiAppUserId(int appUserId);
        int GetirTamamlanmayanGorevSayisiAppUserId(int appUserId);
        int GetirAtanmayıBekleyen();
        int GetirTamamlanmisGorevSayisi();

    }
}
