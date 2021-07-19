using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data.Entity;
using KaraokePayment.Enums;
using KaraokePayment.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace KaraokePayment.Controllers
{
    public class ThanhToanKaraokeController : Controller
    {
        private IPhongDAO _phongDao;
        private IBookPhongOrderPhongDAO _bookPhongOrderPhongDao;
        private IThemHangHoaDAO _themHangHoaDao;
        private IHangHoaDAO _hangHoaDao;
        private IBookPhongOrderDAO _bookPhongOrderDao;
        private UserManager<IdentityUser> khachHang;        

        public ThanhToanKaraokeController(UserManager<IdentityUser> khachHang,IPhongDAO phongDao, IBookPhongOrderPhongDAO bookPhongOrderPhongDao, IThemHangHoaDAO themHangHoaDao, IHangHoaDAO hangHoaDao, IBookPhongOrderDAO bookPhongOrderDao)
        {
            _phongDao = phongDao;
            _bookPhongOrderPhongDao = bookPhongOrderPhongDao;
            _themHangHoaDao = themHangHoaDao;
            _hangHoaDao = hangHoaDao;
            _bookPhongOrderDao = bookPhongOrderDao;

            this.khachHang = khachHang;
        }
        /// <summary>
        /// Return View Thanh Toan
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ThanhToanPhongKaraoke()
        {
            var result = new ThanhToanKaraokeViewModel();
            var phongDangThanhToan = _bookPhongOrderPhongDao.GetPhongDangThanhToan();
            if (phongDangThanhToan!=null && phongDangThanhToan.Any())
            {
                foreach (var bookPhongOrderPhong in phongDangThanhToan)
                {                    
                    var phongItem = new PhongViewModel();
                    var phongId = bookPhongOrderPhong.PhongId;
                    phongItem.Phong = new PhongInfoViewModel(await _phongDao.GetById(phongId));
                    phongItem.HangHoaSuDung = _bookPhongOrderPhongDao.GetHangHoaTheoBookPhong(bookPhongOrderPhong.Id);
                    phongItem.BookPhongOrderPhongId = bookPhongOrderPhong.Id;
                    phongItem.ThoiGianSuDung= Math.Round((bookPhongOrderPhong.ThoiGianKetThuc - bookPhongOrderPhong.ThoiGianBatDau).TotalHours,1);
                    phongItem.TongTienSuDung = bookPhongOrderPhong.TongTien;
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
        public IActionResult ThanhToanTienMat(string bookPhongIds, string thanhToanPhongKaraokeModel)
        {
            List<int> bookPhongOrderPhongIds = JsonConvert.DeserializeObject<List<int>>(bookPhongIds);
            if (bookPhongOrderPhongIds?.Any() != true) return BadRequest();
            var result = HandlingThanhToanThanhCong(bookPhongOrderPhongIds);
            if (result.Result)
            {
                var hoaDonModel = GetHoaDon(KieuThanhToan.TienMat,thanhToanPhongKaraokeModel);
                return View("Views/ThanhToanKaraoke/HoaDonThanhToanKaraoke.cshtml", hoaDonModel);
            }
            return BadRequest();
        }
        
        public async Task<bool> ThanhToanViDienTu(decimal tongTien, List<int> bookPhongOrderPhongIds)
        {
            await HandlingThanhToanThanhCong(bookPhongOrderPhongIds);
            return true;
        }

        public  HoaDonViewModel GetHoaDon(string phuongThucTT, string thanhToanPhongKaraokeModel)
        {
            try
            {
                if (string.IsNullOrEmpty(thanhToanPhongKaraokeModel)) return new HoaDonViewModel();
                var paymentModel = JsonConvert.DeserializeObject<ThanhToanKaraokeViewModel>(thanhToanPhongKaraokeModel);
                if (paymentModel == null) return new HoaDonViewModel();
                var hoaDon = new HoaDonViewModel(paymentModel);
                hoaDon.PhuongThucThanhToan = phuongThucTT;
                // get KH info
                foreach (var item in hoaDon.HoaDonChiTiet)
                {
                    var bookPhongOrderId = _bookPhongOrderPhongDao.GetById(item.BookPhongOrderPhongId)?.Result?.BookPhongOrderId;
                    if (bookPhongOrderId == null || bookPhongOrderId <= 0) continue;
                    string khID = _bookPhongOrderDao.GetById((int)bookPhongOrderId)?.Result?.KhachHangId;
                    if (string.IsNullOrEmpty(khID)) continue;
                    var khInfo = khachHang.Users.FirstOrDefault(x => x.Id.Equals(khID));
                    item.KhachHang = (KhachHang)khInfo;
                }
                var currentUser = khachHang.GetUserAsync(User).Result;
                hoaDon.NhanVien = currentUser !=null?  $"{currentUser.UserName}":"";
                return hoaDon;
            }catch(Exception e)
            {
                throw e;
            }
                      
        }
        #region Logic Inside
        public async Task<bool> HandlingThanhToanThanhCong(List<int> bookPhongOrderPhongIds)
        {
            try
            {
                if (bookPhongOrderPhongIds?.Any() != true) return false;
                foreach (var bookPhongId in bookPhongOrderPhongIds)
                {
                    var phongThanhToan = await _bookPhongOrderPhongDao.GetById(bookPhongId);
                    if (phongThanhToan == null) return false;
                    phongThanhToan.TrangThai = BookPhongOrderPhongStatus.Paid.ToString();
                    phongThanhToan.NgaySua = DateTime.Now;
                    //
                    var phong = await _phongDao.GetById(phongThanhToan.PhongId);
                    if (phong == null) return false;
                    phong.TrangThai = PhongStatus.Empty.ToString();
                    await _bookPhongOrderPhongDao.Update(phongThanhToan);
                    await _phongDao.Update(phong);
                    // check BookPhongOrderFinish
                    var bookPhongOrderData = _bookPhongOrderPhongDao.CheckBookPhongOrderFinish(phongThanhToan.BookPhongOrderId);
                    if (bookPhongOrderData != null)
                    {
                        var bookPhongOrder = await _bookPhongOrderDao.GetById(phongThanhToan.BookPhongOrderId);
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
            catch(Exception e)
            {
                throw e;
            }           
        }
        #endregion

        // Chon phuong thuc thanh toan
        // Vi dien tu :QR code.
        //Click Thanh toan : them hang hoa cho phong, cap nhat thong tin order, cap nhat thong tin phong
    }
}
