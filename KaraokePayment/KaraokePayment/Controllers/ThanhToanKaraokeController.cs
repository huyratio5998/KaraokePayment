using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data.Entity;
using KaraokePayment.Enums;
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
                    phongItem.HangHoaSuDung = _bookPhongOrderPhong.GetHangHoaTheoBookPhong(phong.BookPhongOrderId);
                    phongItem.BookPhongOrderPhongId = phong.BookPhongOrderId;
                    result.PhongThanhToan.Add(phongItem);
                }
            }
            return View(result);
        }

        public async Task<IActionResult> ThemPhongThanhToan(int phongId)
        {
            if(phongId<=0) return BadRequest();
            var giaPhong = _phongDao.GetById(phongId).Result.Gia;
            await _bookPhongOrderPhong.ThemPhongThanhToan(phongId,giaPhong);
            return RedirectToAction("ThanhToanPhongKaraoke");
        }

        // Chon phuong thuc thanh toan
        // Vi dien tu :QR code.
        //Click Thanh toan : them hang hoa cho phong, cap nhat thong tin order, cap nhat thong tin phong
    }
}
