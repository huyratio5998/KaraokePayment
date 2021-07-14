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

        public List<HangHoaViewModel> GetHangHoaTheoBookPhong(int bookPhongOrderPhongId)
        {
            var themHangHoa = _context.ThemHangHoas.Where(x => x.BookPhongOrderPhongId == bookPhongOrderPhongId).Select(x =>
                new HangHoaViewModel()
                {
                    HangHoaInfo = _context.HangHoas.FirstOrDefault(t => t.Id == x.HangHoaId),
                    SoLuongSuDung = x.SoLuong,
                });
            return themHangHoa.ToList();
        }

        public async Task ThemPhongThanhToan(int phongId, decimal giaPhong)
        {
            var bookPhongOrderPhong =  _context.BookPhongOrderPhongs.AsEnumerable().Where(x=>x.PhongId==phongId).FirstOrDefault(x =>
                (x.TrangThai.Equals(BookPhongOrderPhongStatus.Using.ToString(), StringComparison.OrdinalIgnoreCase) ||
                 x.TrangThai.Equals(BookPhongOrderPhongStatus.Paying.ToString(), StringComparison.OrdinalIgnoreCase)));
            if(bookPhongOrderPhong==null) return;
            bookPhongOrderPhong.NgaySua=DateTime.Now;
            bookPhongOrderPhong.ThoiGianKetThuc=DateTime.Now;
            bookPhongOrderPhong.TrangThai = BookPhongOrderPhongStatus.Paying.ToString();
            var hours = (bookPhongOrderPhong.ThoiGianKetThuc - bookPhongOrderPhong.ThoiGianBatDau).TotalHours;
            bookPhongOrderPhong.TongTien = Convert.ToDecimal(Math.Round(hours, 1)) * giaPhong;
            await Update(bookPhongOrderPhong);
        }
    }
}
