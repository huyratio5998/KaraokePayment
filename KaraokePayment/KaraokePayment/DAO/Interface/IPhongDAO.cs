using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.DAO.Interface
{
    public interface IPhongDAO : IDAO<Phong>
    {
        List<Phong> GetPhongDaBook();
        Phong GetPhongTheoTen(string name);
    }
}
