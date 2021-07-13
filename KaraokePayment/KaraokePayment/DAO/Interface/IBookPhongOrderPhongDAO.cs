using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;
using KaraokePayment.Models;

namespace KaraokePayment.DAO.Interface
{
    public interface IBookPhongOrderPhongDAO : IDAO<BookPhongOrderPhong>
    {
        bool ThemHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId, int soLuong);
        Task<bool> ThanhToanPhong(int bookPhongOrderPhongId);
        List<BookPhongOrderPhong> GetHoaDon(List<int> bookPhongOrderPhongId);
        Task<BookPhongOrderPhong> GetBookPhongInfo(int bookPhongOrderPhongId);
        List<BookPhongOrderPhong> GetPhongDangThanhToan();
        List<HangHoaViewModel> GetHangHoaTheoPhong(int phongId);
    }
}