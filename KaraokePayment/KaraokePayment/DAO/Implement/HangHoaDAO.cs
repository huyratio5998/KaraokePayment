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

        public async Task<List<HangHoa>> GetHangHoaTheoTen(string tenHH)
        {
            if (!string.IsNullOrEmpty(tenHH))
            {
                var result = _context.HangHoas.Where(x => x.Ten.Contains(tenHH, StringComparison.OrdinalIgnoreCase)).ToList();
                if (result != null && result.Any()) return result;
            }
            var hanghoas = await GetAll();
            return hanghoas.ToList();
        }
    }
}
