using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;
using KaraokePayment.Enums;

namespace KaraokePayment.DAO.Implement
{
    public class PhongDAO : DAO<Phong>, IPhongDAO
    {
        public PhongDAO(KaraokeDbContext context) : base(context)
        {
        }
        public List<Phong> GetPhongDaBook()
        {
            var phongs = _context.Phongs.AsEnumerable().Where(x => x.TrangThai.Equals(PhongStatus.Occupied.ToString(),StringComparison.OrdinalIgnoreCase)).ToList();
            if (phongs != null && phongs.Any())
            {
                return phongs;
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
