using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.DAO.Implement
{
    public class PhongDAO : DAO<Phong>, IPhongDAO
    {
        public PhongDAO(KaraokeDbContext context) : base(context)
        {
        }
        public List<Phong> GetPhongDaBook()
        {
            var phongs = _context.Phongs.Where(x => x.TrangThai.Equals("occupied",StringComparison.OrdinalIgnoreCase));
            if (phongs != null && phongs.Any())
            {
                return phongs.ToList();
            }

            return new List<Phong>();
        }

        public Phong GetPhongTheoTen(string name)
        {
            var phong = _context.Phongs.FirstOrDefault(x =>
                x.TenPhong.Equals(name, StringComparison.OrdinalIgnoreCase));
            return phong;
        }

       
    }
}
