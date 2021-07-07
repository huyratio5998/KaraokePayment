using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace KaraokePayment.DAO.Implement
{
    public class BookPhongOrderPhongDAO: DAO<BookPhongOrderPhong>, IBookPhongOrderPhongDAO
    {
        
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
                _context.ThemHangHoas.Add(themHang);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> ThanhToanPhong(int bookPhongOrderPhongId)
        {
            var bookPhong=await GetById(bookPhongOrderPhongId);
            if (bookPhong == null) return false;
            bookPhong.TrangThai = "paid";
            _context.Entry(bookPhong).State = EntityState.Modified;
            _context.SaveChanges();
            return true;

        }

        public List<BookPhongOrderPhong> GetHoaDon(List<int> bookPhongOrderPhongId)
        {
            var lstHoaDon = new List<BookPhongOrderPhong>();
            foreach (var item in bookPhongOrderPhongId)
            {
                var hoaDon =_context.BookPhongOrderPhongs.Where(x => x.Id == item).ToList();
                if(hoaDon!=null && hoaDon.Any()) lstHoaDon.AddRange(hoaDon);
            }

            return lstHoaDon;
        }

        public Task<BookPhongOrderPhong> GetBookPhongInfo(int bookPhongOrderPhongId)
        {
            var bookPhongInfo = GetById(bookPhongOrderPhongId);
            return bookPhongInfo;
        }

        protected BookPhongOrderPhongDAO(KaraokeDbContext context) : base(context)
        {
        }
    }
}
