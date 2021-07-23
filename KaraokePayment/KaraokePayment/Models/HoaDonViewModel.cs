using KaraokePayment.Data.Entity;
using KaraokePayment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Models
{
    public class HoaDonViewModel
    {
        public HoaDonViewModel()
        {            
        }
        public HoaDonViewModel(ThanhToanKaraokeViewModel paymentModel)
        {
            NgayThanhToan = DateTime.Now;
            TongTienTT = PaymentHelper.ConvertCurrency(paymentModel.TongThanhToan);
            HoaDonChiTiet = new List<BillDetailViewModel>();
            foreach (var item in paymentModel.PhongThanhToan)
            {
                var billDetail = new BillDetailViewModel() { 
                    Phong=item.Phong,
                    ThoiGianSuDung=item.ThoiGianSuDung,
                    TongTienSuDung=item.TongTienSuDung,
                    BookPhongOrderPhongId=item.BookPhongOrderPhongId
                };
                // them phong
                var phongSP = new SanPham(item.Phong);
                phongSP.ThoiGian = item.ThoiGianSuDung;
                phongSP.TongTien =PaymentHelper.ConvertCurrency(item.TongTienSuDung);
                billDetail.DanhSachSanPham.Add(phongSP);
                // them sp cua phong
                foreach (var hh in item.HangHoaSuDung)
                {
                    var sanPham = new SanPham(hh);
                    billDetail.DanhSachSanPham.Add(sanPham);
                }
                //
                HoaDonChiTiet.Add(billDetail);
            }
        }
        public string NhanVien { get; set; }
        public string NguoiThanhToan { get; set; }
        public List<BillDetailViewModel> HoaDonChiTiet{ get; set; }        
        public DateTime NgayThanhToan { get; set; }
        public string PhuongThucThanhToan { get; set; }        
        public string TongTienTT { get; set; }

    }
}
