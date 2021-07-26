using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace KaraokePayment.DAO.Implement
{
    public class ThemHangHoaDAO : DAO<ThemHangHoa>, IThemHangHoaDAO
    {
        public ThemHangHoaDAO(KaraokeDbContext context) : base(context)
        {
        }
        public bool ThemHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId, int soLuong)
        {
            try
            {
                var themHang = new ThemHangHoa()
                {
                    SoLuong = soLuong,
                    HangHoaId = hangHoaId,
                    BookPhongOrderPhongId = bookPhongOrderPhongId
                };
                var hangHoaExist = _context.ThemHangHoas.FirstOrDefault(x => x.BookPhongOrderPhongId == bookPhongOrderPhongId && x.HangHoaId == hangHoaId);
                if (hangHoaExist != null)
                {
                    _context.ThemHangHoas.Attach(hangHoaExist);
                    hangHoaExist.SoLuong += themHang.SoLuong;
                }
                else
                {
                    _context.ThemHangHoas.Add(themHang);
                }               
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public int XoaHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId)
        {
            try
            {
                var hangHoaPhong = _context.ThemHangHoas.AsEnumerable().FirstOrDefault(x =>
                    x.BookPhongOrderPhongId == bookPhongOrderPhongId && x.HangHoaId == hangHoaId);
                var soLuongHH = hangHoaPhong.SoLuong;
                if (hangHoaPhong == null) return 0;
                Delete(hangHoaPhong);
                return soLuongHH;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool XoaTatCaHangHoaPhong(int bookPhongOrderPhongId)
        {
            try
            {
                var hangHoaPhongs = _context.ThemHangHoas.AsEnumerable().Where(x => x.BookPhongOrderPhongId == bookPhongOrderPhongId);
                // tra lai so luong hh
                foreach (var item in hangHoaPhongs)
                {
                    var hangHoa = _context.HangHoas.FirstOrDefault(x => x.Id == item.HangHoaId);
                    if (hangHoa != null)
                    {
                        hangHoa.SoLuong += item.SoLuong;
                        _context.HangHoas.Attach(hangHoa);
                        _context.Entry(hangHoa).State = EntityState.Modified;                        
                    }
                }                
                if (hangHoaPhongs?.Any()!=true) return true;
                _context.ThemHangHoas.RemoveRange(hangHoaPhongs);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
