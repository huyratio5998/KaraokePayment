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
using Microsoft.AspNetCore.Authorization;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.pipeline.css;
using KaraokePayment.Models.VNPay;
using KaraokePayment.Helpers;

namespace KaraokePayment.Controllers
{
    [Authorize]
    public class ThanhToanKaraokeController : Controller
    {
        private IPhongDAO _phongDao;
        private IBookPhongOrderPhongDAO _bookPhongOrderPhongDao;
        private IThemHangHoaDAO _themHangHoaDao;
        private IHangHoaDAO _hangHoaDao;
        private IBookPhongOrderDAO _bookPhongOrderDao;
        private UserManager<IdentityUser> khachHang;
        public ThanhToanKaraokeController(UserManager<IdentityUser> khachHang, IPhongDAO phongDao, IBookPhongOrderPhongDAO bookPhongOrderPhongDao, IThemHangHoaDAO themHangHoaDao, IHangHoaDAO hangHoaDao, IBookPhongOrderDAO bookPhongOrderDao)
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
        public async Task<IActionResult> ThanhToanPhongKaraoke(string vnp_Amount, string vnp_BankCode, string vnp_BankTranNo, string vnp_CardType,
            string vnp_OrderInfo, string vnp_PayDate, string vnp_ResponseCode, string vnp_TmnCode, string vnp_TransactionNo, string vnp_TxnRef,
            string vnp_SecureHashType, string vnp_SecureHash)
        {
            // handling pay by vnpay
            var isReturnSuccess = PaymentHelper.ValidatePaymentSuccess(vnp_Amount, vnp_BankCode, vnp_BankTranNo, vnp_CardType, vnp_OrderInfo, vnp_PayDate, vnp_ResponseCode, vnp_TmnCode, vnp_BankTranNo,
                vnp_TxnRef, vnp_SecureHashType, vnp_SecureHash);
            var boolValue = isReturnSuccess ? "true" : "false";
            ViewBag.IsReturnSuccess = boolValue;
            //
            var result = new ThanhToanKaraokeViewModel();
            var phongDangThanhToan = _bookPhongOrderPhongDao.GetPhongDangThanhToan();
            if (phongDangThanhToan != null && phongDangThanhToan.Any())
            {
                foreach (var bookPhongOrderPhong in phongDangThanhToan)
                {
                    var phongItem = new PhongViewModel();
                    var phongId = bookPhongOrderPhong.PhongId;
                    phongItem.Phong = new PhongInfoViewModel(await _phongDao.GetById(phongId));
                    phongItem.HangHoaSuDung = _bookPhongOrderPhongDao.GetHangHoaTheoBookPhong(bookPhongOrderPhong.Id);
                    phongItem.BookPhongOrderPhongId = bookPhongOrderPhong.Id;
                    var useHour = (bookPhongOrderPhong.ThoiGianKetThuc - bookPhongOrderPhong.ThoiGianBatDau).TotalHours;
                    if (useHour <= 1) useHour = 1;
                    phongItem.ThoiGianSuDung = Math.Round(useHour, 1);
                    phongItem.TongTienSuDung = bookPhongOrderPhong.TongTien;
                    result.PhongThanhToan.Add(phongItem);
                }
            }
            return View(result);
        }

        public async Task<IActionResult> ThemPhongThanhToan(int phongId)
        {
            if (phongId <= 0) return BadRequest();
            var themPhong = await _phongDao.GetById(phongId);
            if (themPhong == null) return BadRequest();
            var giaPhong = themPhong?.Gia ?? 0;
            themPhong.TrangThai = PhongStatus.Paying;
            var isSuccess = await _bookPhongOrderPhongDao.ThemPhongThanhToan(phongId, giaPhong);
            if (isSuccess) await _phongDao.Update(themPhong);
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
        public async Task<IActionResult> ThemHangHoaPhong(int bookPhongOrderPhongId, int hangHoaId, int soLuong)
        {
            if (soLuong <= 0) soLuong = 1;
            var getHangHoa = await _hangHoaDao.GetById(hangHoaId);
            var hangHoaConLai = getHangHoa.SoLuong;
            if (hangHoaConLai < soLuong)
                {
                    var hangHoas = _hangHoaDao.GetHangHoaAvailable();
                    return View("ThemHangHoaPhongError");
                }
            var check = _themHangHoaDao.ThemHangHoaPhong(bookPhongOrderPhongId, hangHoaId, soLuong);
            if (!check) return BadRequest();
            // tru hang hoa
            getHangHoa.SoLuong -= soLuong;
            await _hangHoaDao.Update(getHangHoa);
            return RedirectToAction("ThanhToanPhongKaraoke", "ThanhToanKaraoke");
        }
        //view them phong error
        public IActionResult ThemHangHoaPhongError()
        {           
            return View();
        }
        public async Task<IActionResult> XoaHangHoaThanhToan(int bookPhongOrderPhongId, int hangHoaId)
        {
            var soLuongHH = _themHangHoaDao.XoaHangHoaPhong(bookPhongOrderPhongId, hangHoaId);
            if (soLuongHH == 0) return BadRequest();
            var getHangHoa = await _hangHoaDao.GetById(hangHoaId);
            if (getHangHoa != null)
            {
                getHangHoa.SoLuong += soLuongHH;
                await _hangHoaDao.Update(getHangHoa);
            }
            return RedirectToAction("ThanhToanPhongKaraoke");
        }

        public async Task<IActionResult> XoaPhongThanhToan(int bookPhongOrderPhongId)
        {
            var phongThanhToan = await _bookPhongOrderPhongDao.GetById(bookPhongOrderPhongId);
            if (phongThanhToan == null) return BadRequest();
            var phongId = phongThanhToan.PhongId;
            var updateBookPhongOrderPhong = await _bookPhongOrderPhongDao.XoaPhongThanhToan(phongThanhToan);
            if (updateBookPhongOrderPhong)
            {
                var isNext = _themHangHoaDao.XoaTatCaHangHoaPhong(bookPhongOrderPhongId);
                if (phongId > 0)
                {
                    //update phong status
                    var phong = await _phongDao.GetById(phongId);
                    if (phong == null) return BadRequest();
                    phong.TrangThai = PhongStatus.Occupied;
                    await _phongDao.Update(phong);
                    if (isNext) return RedirectToAction("ThanhToanPhongKaraoke");
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> ThanhToanTienMat(string bookPhongIds, string thanhToanPhongKaraokeModel)
        {
            List<int> bookPhongOrderPhongIds = JsonConvert.DeserializeObject<List<int>>(bookPhongIds);
            if (bookPhongOrderPhongIds?.Any() != true) return BadRequest();
            var result =await HandlingThanhToanThanhCong(bookPhongOrderPhongIds);
            if (result)
            {
                var hoaDonModel = GetHoaDon(KieuThanhToan.TienMat, thanhToanPhongKaraokeModel);
                return View("Views/ThanhToanKaraoke/HoaDonThanhToanKaraoke.cshtml", hoaDonModel);
            }

            return BadRequest();
        }
        [HttpPost]
        public string ThanhToanViDienTu(string tongTien, string bookPhongIds)
        {
            //
            List<int> bookPhongOrderPhongIds = JsonConvert.DeserializeObject<List<int>>(bookPhongIds);
            if (bookPhongOrderPhongIds?.Any() != true) return string.Empty;
            string orderId = string.Join("-", bookPhongOrderPhongIds);
            try
            {
                var resultUrl = CreateVNPayUrl(decimal.Parse(tongTien), orderId);
                return resultUrl;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public HoaDonViewModel GetHoaDon(string phuongThucTT, string thanhToanPhongKaraokeModel)
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
                    var bookPhongOrderPhong = _bookPhongOrderPhongDao.GetById(item.BookPhongOrderPhongId)?.Result;
                    var nvCaLV1Id = bookPhongOrderPhong.NhanVienBook1Id;
                    var nvCaLV2Id = bookPhongOrderPhong.NhanVienBook2Id;
                    item.NV1 = _bookPhongOrderPhongDao.GetNhanVienByNVCaLVId(nvCaLV1Id);
                    item.NV2 = _bookPhongOrderPhongDao.GetNhanVienByNVCaLVId(nvCaLV2Id);
                    var bookPhongOrderId = bookPhongOrderPhong?.BookPhongOrderId;
                    if (bookPhongOrderId == null || bookPhongOrderId <= 0) continue;
                    string khID = _bookPhongOrderDao.GetById((int)bookPhongOrderId)?.Result?.KhachHangId;
                    if (string.IsNullOrEmpty(khID)) continue;
                    var khInfo = khachHang.Users.FirstOrDefault(x => x.Id.Equals(khID));
                    item.KhachHang = (KhachHang)khInfo;
                }
                var currentUser = khachHang.GetUserAsync(User).Result;
                hoaDon.NhanVien = currentUser != null ? $"{currentUser.UserName}" : "";
                return hoaDon;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #region VNPay
        public string CreateVNPayUrl(decimal tongTien, string orderId)
        {
            var description = $"Thanh toan Karaoke ngay:{DateTime.Now.ToString("dd/MM/yyyy")} Huyratio";
            //Get Config Info
            string vnp_Returnurl = VNPaySetting.vnp_Returnurl;
            string vnp_Url = VNPaySetting.vnp_Url;
            string vnp_TmnCode = VNPaySetting.vnp_TmnCode;
            string vnp_HashSecret = VNPaySetting.vnp_HashSecret;
            if (string.IsNullOrEmpty(vnp_TmnCode) || string.IsNullOrEmpty(vnp_HashSecret)) return string.Empty;
            //Build URL for VNPAY
            string tongTienTT = (tongTien * 100).ToString("G29");
            var requestApi = new UrlRequestApi(vnp_TmnCode, tongTienTT, description, vnp_Returnurl, orderId);
            VnPayLibrary vnpay = new VnPayLibrary(requestApi);

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            return paymentUrl;
            //Response.Redirect(paymentUrl);
        }
        #endregion
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
                    phongThanhToan.TrangThai = BookPhongOrderPhongStatus.Paid;
                    phongThanhToan.NgaySua = DateTime.Now;
                    //
                    var phong = await _phongDao.GetById(phongThanhToan.PhongId);
                    if (phong == null) return false;
                    phong.TrangThai = PhongStatus.Empty;
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
            catch (Exception e)
            {
                throw e;
            }
        }
        // not use
        [HttpPost]
        public FileResult ExportPdf(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
        #endregion


    }
}
