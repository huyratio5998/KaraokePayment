using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Models
{
    public class SanPham
    {
        public SanPham(PhongInfoViewModel phongSP)
        {
            Ten = phongSP.TenPhong;
            SoLuong = 1;
            Gia = phongSP.Gia;
            IsPhong = true;            
        }
        public SanPham(HangHoaViewModel hangHoa)
        {
            Ten = hangHoa.HangHoaInfo.Ten;
            SoLuong = hangHoa.SoLuongSuDung;
            Gia = hangHoa.HangHoaInfo.Gia;
            TongTien = this.SoLuong * this.Gia;
            IsPhong = false;
            ThoiGian = null;
        }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public double? ThoiGian { get; set; }
        public decimal TongTien { get; set; }
        public bool IsPhong { get; set; }
    }
}
