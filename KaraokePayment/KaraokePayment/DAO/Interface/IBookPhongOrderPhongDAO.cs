using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.DAO.Interface
{
    public interface IBookPhongOrderPhongDAO : IBaseDAO<BookPhongOrderPhong>
    {
        bool ThemHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId, int soLuong);
        Task<bool> ThanhToanPhong(int bookPhongOrderPhongId);
        Task<List<BookPhongOrderPhong>> GetHoaDon(List<int> bookPhongOrderPhongId);
        Task<BookPhongOrderPhong> GetBookPhongInfo(int bookPhongOrderPhongId);
    }
}
