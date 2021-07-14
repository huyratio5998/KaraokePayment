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
        Task<bool> ThanhToanPhong(int bookPhongOrderPhongId);
        List<BookPhongOrderPhong> GetHoaDon(List<int> bookPhongOrderPhongId);
        Task<BookPhongOrderPhong> GetBookPhongInfo(int bookPhongOrderPhongId);
        List<BookPhongOrderPhong> GetPhongDangThanhToan();
        List<HangHoaViewModel> GetHangHoaTheoBookPhong(int bookPhongOrderPhongId);
        Task ThemPhongThanhToan(int phongId, decimal giaPhong);
    }
}