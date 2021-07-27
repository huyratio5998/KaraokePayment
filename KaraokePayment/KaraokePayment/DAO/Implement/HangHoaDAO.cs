using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.DAO.Implement
{
    public class HangHoaDAO : DAO<HangHoa>,IHangHoaDAO
    {
        public HangHoaDAO(KaraokeDbContext context) : base(context)
        {
        }

        public List<HangHoa> GetHangHoaAvailable()
        {
            return _context.HangHoas.Where(x => x.SoLuong > 0).ToList();
        }     
    }
}
