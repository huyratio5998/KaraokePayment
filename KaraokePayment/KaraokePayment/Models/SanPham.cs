using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Helpers;
namespace KaraokePayment.Models
{
    public class SanPham
    {
        public SanPham(PhongInfoViewModel phongSP)
        {
            Ten = phongSP.TenPhong.StringCapitalization();
            SoLuong = 1;
            Gia = PaymentHelper.ConvertCurrency(phongSP.Gia);
            IsPhong = true;            
        }
        public SanPham(HangHoaViewModel hangHoa)
        {
            Ten = hangHoa.HangHoaInfo.Ten.StringCapitalization();
            SoLuong = hangHoa.SoLuongSuDung;
            Gia = PaymentHelper.ConvertCurrency(hangHoa.HangHoaInfo.Gia);
            TongTien = PaymentHelper.ConvertCurrency( this.SoLuong * hangHoa.HangHoaInfo.Gia);
            IsPhong = false;
            ThoiGian = null;
        }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public string Gia { get; set; }
        public double? ThoiGian { get; set; }
        public string TongTien { get; set; }
        public bool IsPhong { get; set; }
    }
}
