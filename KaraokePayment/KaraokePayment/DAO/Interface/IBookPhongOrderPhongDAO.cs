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
        List<BookPhongOrderPhong> GetPhongDangThanhToan();
        List<HangHoaViewModel> GetHangHoaTheoBookPhong(int bookPhongOrderPhongId);
        Task<bool> ThemPhongThanhToan(int phongId, decimal giaPhong);
        Task<bool> XoaPhongThanhToan(BookPhongOrderPhong phongThanhToan);
        BookPhongOrder CheckBookPhongOrderFinish(int bookPhongOrderId);
        string GetNhanVienByNVCaLVId(int nvCaLVId);
    }
}