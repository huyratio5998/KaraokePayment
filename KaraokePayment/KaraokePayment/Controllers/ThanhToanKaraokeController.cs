using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data.Entity;
using KaraokePayment.Models;

namespace KaraokePayment.Controllers
{
    public class ThanhToanKaraokeController : Controller
    {
        public IPhongDAO _phongDao;
        public IBookPhongOrderPhongDAO _bookPhongOrderPhong;

        public ThanhToanKaraokeController(IPhongDAO phongDao, IBookPhongOrderPhongDAO bookPhongOrderPhong)
        {
            _phongDao = phongDao;
            _bookPhongOrderPhong = bookPhongOrderPhong;
        }

        public async Task<IActionResult> ThanhToanPhongKaraoke()
        {
            var result = new ThanhToanKaraokeViewModel();
            var phongDangThanhToan = _bookPhongOrderPhong.GetPhongDangThanhToan();
            if (phongDangThanhToan!=null && phongDangThanhToan.Any())
            {
                foreach (var phong in phongDangThanhToan)
                {
                    var tongTienHangHoa = 0;
                    var phongItem = new PhongViewModel();
                    var phongId = phong.PhongId;
                    phongItem.Phong = await _phongDao.GetById(phongId);
                    phongItem.HangHoaSuDung = _bookPhongOrderPhong.GetHangHoaTheoPhong(phongId);
                }
            }
            return View(result);
        }

        // Chon phuong thuc thanh toan
        // Vi dien tu :QR code.
        //Click Thanh toan : them hang hoa cho phong, cap nhat thong tin order, cap nhat thong tin phong
    }
}
