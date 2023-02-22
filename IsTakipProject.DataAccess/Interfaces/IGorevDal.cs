using IsTakipProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IsTakipProject.DataAccess.Interfaces
{
    public interface IGorevDal: IGenericDal<Gorev>
    {
        List<Gorev> GetirAciliyetIleTamamlanmayan();
        List<Gorev> GetirTumTablolarla();
        List<Gorev> GetirTumTablolarlaTamamlanan(out int toplamSayfa,int appUserId,int aktifSayfa=1);
        List<Gorev> GetirTumTablolarla(Expression<Func<Gorev,bool>> filter);
        Gorev GetirAciliyetileId(int id);
        List<Gorev> GetirileAppUserId(int appUserId);
        Gorev GetirRaporlarileAppUserbyId(int id);
        List<Gorev> GetirTamamlanmisGorevlerTumTablolarla(out int toplamSayfa, int aktifSayfa = 1);
        int GetirTamamlananGorevSayisiAppUserId(int appUserId);
        int GetirTamamlanmayanGorevSayisiAppUserId(int appUserId);
        int GetirAtanmayıBekleyen();
        int GetirTamamlanmisGorevSayisi();
    }
}
