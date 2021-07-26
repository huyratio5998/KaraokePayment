using KaraokePayment.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Models
{
    public class BillDetailViewModel
    {
        public BillDetailViewModel()
        {
            DanhSachSanPham = new List<SanPham>();
        }
        public KhachHang KhachHang { get; set; }
        public int BookPhongOrderPhongId { get; set; }
        public PhongInfoViewModel Phong { get; set; }                
        public double ThoiGianSuDung { get; set; }
        public decimal TongTienSuDung { get; set; }
        public List<SanPham> DanhSachSanPham { get; set; }
        public string NV1 { get; set; }
        public string NV2 { get; set; }
    }
}
