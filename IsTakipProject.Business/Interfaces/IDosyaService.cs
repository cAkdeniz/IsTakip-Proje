using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Business.Interfaces
{
    public interface IDosyaService
    {
        string AktarPdf<T>(List<T> list);
        byte[] AktarExcel<T>(List<T> list);
    }
}
