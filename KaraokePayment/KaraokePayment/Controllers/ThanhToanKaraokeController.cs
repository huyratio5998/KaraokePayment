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
        public IBookPhongOrderPhongDAO _bookPhongOrderPhongDao;
        public IThemHangHoaDAO _themHangHoaDao;
        public IHangHoaDAO _hangHoaDao;
        public IBookPhongOrderDAO _bookPhongOrderDao;
        public ThanhToanKaraokeController(IPhongDAO phongDao, IBookPhongOrderPhongDAO bookPhongOrderPhongDao, IThemHangHoaDAO themHangHoaDao, IHangHoaDAO hangHoaDao, IBookPhongOrderDAO bookPhongOrderDao)
        {
            _phongDao = phongDao;
            _bookPhongOrderPhongDao = bookPhongOrderPhongDao;
            _themHangHoaDao = themHangHoaDao;
            _hangHoaDao = hangHoaDao;
            _bookPhongOrderDao = bookPhongOrderDao;
        }

        public async Task<IActionResult> ThanhToanPhongKaraoke()
        {
            var result = new ThanhToanKaraokeViewModel();
            var phongDangThanhToan = _bookPhongOrderPhongDao.GetPhongDangThanhToan();
            if (phongDangThanhToan!=null && phongDangThanhToan.Any())
            {
                foreach (var phong in phongDangThanhToan)
                {
                    var tongTienHangHoa = 0;
                    var phongItem = new PhongViewModel();
                    var phongId = phong.PhongId;
                    phongItem.Phong = await _phongDao.GetById(phongId);
                    phongItem.HangHoaSuDung = _bookPhongOrderPhongDao.GetHangHoaTheoBookPhong(phong.BookPhongOrderId);
                    phongItem.BookPhongOrderPhongId = phong.BookPhongOrderId;
                    phongItem.ThoiGianSuDung= Math.Round((phong.ThoiGianKetThuc - phong.ThoiGianBatDau).TotalHours,1);
                    phongItem.TongTienSuDung = phong.TongTien;
                    result.PhongThanhToan.Add(phongItem);
                }
            }
            return View(result);
        }

        public async Task<IActionResult> ThemPhongThanhToan(int phongId)
        {
            if(phongId<=0) return BadRequest();
            var themPhong =await _phongDao.GetById(phongId);
            if (themPhong == null) return BadRequest();
            var giaPhong = themPhong?.Gia ?? 0;
            themPhong.TrangThai = PhongStatus.Paying.ToString();
            var isSuccess= await _bookPhongOrderPhongDao.ThemPhongThanhToan(phongId,giaPhong);
            if(isSuccess) await _phongDao.Update(themPhong);
            return RedirectToAction("ThanhToanPhongKaraoke");
        }

        public IActionResult ThemHangHoaPhong(int bookPhongOrderPhongId)
        {
            ViewBag.BookPhongOrderPhongId = bookPhongOrderPhongId;
            var hangHoas = _hangHoaDao.GetHangHoaAvailable();
            return View(hangHoas);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId, int soLuong)
        {
            var check = _themHangHoaDao.ThemHangHoaPhong(bookPhongOrderPhongId, hangHoaId, soLuong);
            if (!check) return BadRequest();
            return RedirectToAction("ThanhToanPhongKaraoke", "ThanhToanKaraoke");
        }

        public IActionResult XoaHangHoaThanhToan(int bookPhongOrderPhongId, int hangHoaId)
        {
            _themHangHoaDao.XoaHangHoaPhong(bookPhongOrderPhongId, hangHoaId);
            return RedirectToAction("ThanhToanPhongKaraoke");
        }

        public async Task<IActionResult> XoaPhongThanhToan(int bookPhongOrderPhongId)
        {
            var phongThanhToan =await _bookPhongOrderPhongDao.GetById(bookPhongOrderPhongId);
            if (phongThanhToan == null) return BadRequest();
            var phongId = phongThanhToan.PhongId;
            var updateBookPhongOrderPhong =await _bookPhongOrderPhongDao.XoaPhongThanhToan(phongThanhToan);
            if (updateBookPhongOrderPhong)
            {
               var isNext= _themHangHoaDao.XoaTatCaHangHoaPhong(bookPhongOrderPhongId);
               if (phongId >0)
               {
                   var phong=await _phongDao.GetById(phongId);
                   if (phong == null) return BadRequest();
                   phong.TrangThai = PhongStatus.Occupied.ToString();
                   await _phongDao.Update(phong);
                   if (isNext) return RedirectToAction("ThanhToanPhongKaraoke");
                   return BadRequest();
               }
            }
            return BadRequest();
        }

        [HttpPost]            
        public IActionResult ThanhToanTienMat(List<int> bookPhongOrderPhongIds)
        {
            //List<int> bookPhongOrderPhongIds = new List<int>();
            if (bookPhongOrderPhongIds?.Any() != true) return BadRequest();
            //var result = HandlingThanhToanThanhCong(bookPhongOrderPhongIds);
            
            //if (result.Result) return RedirectToAction("ThanhToanPhongKaraoke");
            return BadRequest();
        }

        public async Task<bool> ThanhToanViDienTu(decimal tongTien, List<int> bookPhongOrderPhongIds)
        {
            await HandlingThanhToanThanhCong(bookPhongOrderPhongIds);
            return true;
        }

        public async Task<bool> HandlingThanhToanThanhCong(List<int> bookPhongOrderPhongIds)
        {
            if (bookPhongOrderPhongIds?.Any() != true) return false;
            foreach (var bookPhongId in bookPhongOrderPhongIds)
            {
                var phongThanhToan = await _bookPhongOrderPhongDao.GetById(bookPhongId);
                if(phongThanhToan==null) return false;
                phongThanhToan.TrangThai = BookPhongOrderPhongStatus.Paid.ToString();
                phongThanhToan.NgaySua=DateTime.Now;
                //
                var phong =await _phongDao.GetById(phongThanhToan.PhongId);
                if (phong == null) return false;
                phong.TrangThai = PhongStatus.Empty.ToString();
                await _bookPhongOrderPhongDao.Update(phongThanhToan);
                await _phongDao.Update(phong);
                // check BookPhongOrderFinish
                var bookPhongOrderData = _bookPhongOrderPhongDao.CheckBookPhongOrderFinish(phongThanhToan.BookPhongOrderId);
                if (bookPhongOrderData != null)
                {
                    var bookPhongOrder =await _bookPhongOrderDao.GetById(phongThanhToan.BookPhongOrderId);
                    if (bookPhongOrder != null)
                    {
                        bookPhongOrder.TrangThai = bookPhongOrderData.TrangThai;
                        bookPhongOrder.TongTT = bookPhongOrderData.TongTT;
                        await _bookPhongOrderDao.Update(bookPhongOrder);
                    }
                }
            }
            return true;
        }
        // Chon phuong thuc thanh toan
        // Vi dien tu :QR code.
        //Click Thanh toan : them hang hoa cho phong, cap nhat thong tin order, cap nhat thong tin phong
    }
}
