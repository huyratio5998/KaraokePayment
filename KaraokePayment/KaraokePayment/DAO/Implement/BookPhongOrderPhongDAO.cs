using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;
using KaraokePayment.Enums;
using KaraokePayment.Models;
using Microsoft.EntityFrameworkCore;

namespace KaraokePayment.DAO.Implement
{
    public class BookPhongOrderPhongDAO: DAO<BookPhongOrderPhong>, IBookPhongOrderPhongDAO
    {
        public BookPhongOrderPhongDAO(KaraokeDbContext context) : base(context)
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

        public List<BookPhongOrderPhong> GetPhongDangThanhToan()
        {

            var result = _context.BookPhongOrderPhongs
                .Where(x => x.TrangThai.Equals(BookPhongOrderPhongStatus.Paying.ToString())).ToList();
            return result.Any() ? result : new List<BookPhongOrderPhong>();
        }

        public List<HangHoaViewModel> GetHangHoaTheoPhong(int phongId)
        {
            var themHangHoa = _context.ThemHangHoas.Where(x => x.BookPhongOrderPhongId == phongId).Select(x =>
                new HangHoaViewModel()
                {
                    HangHoaInfo = _context.HangHoas.FirstOrDefault(t => t.Id == x.HangHoaId),
                    SoLuongSuDung = x.SoLuong,
                });
            return themHangHoa.ToList();
        }
    }
}
