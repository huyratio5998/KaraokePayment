using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.DAO.Interface
{
    public interface IThemHangHoaDAO
    {
        bool ThemHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId, int soLuong);
        int XoaHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId);
        bool XoaTatCaHangHoaPhong(int bookPhongOrderPhongId);
    }
}
