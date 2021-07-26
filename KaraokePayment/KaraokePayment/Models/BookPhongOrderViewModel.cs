using KaraokePayment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Models
{
    public class BookPhongOrderViewModel
    {
        public int Id { get; set; }
        public decimal TongTT { get; set; }
        public BookPhongOrderStatus TrangThai { get; set; }
                
        public string KhachHang { get; set; }
        
        public string NhanVienAdmin{ get; set; }
    }
}
