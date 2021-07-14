using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.DAO.Interface
{
    public interface IHangHoaDAO : IDAO<HangHoa>
    {
        List<HangHoa> GetHangHoaAvailable();
        Task<List<HangHoa>> GetHangHoaTheoTen(string tenHH);
        bool ThemHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId, int soLuong);
    }
}
