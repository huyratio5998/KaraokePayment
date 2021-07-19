using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.Models
{
    public class HangHoaViewModel
    {
        public HangHoaInfoViewModel HangHoaInfo { get; set; }
        public int SoLuongSuDung { get; set; }
        public decimal TongTienHHPhong { get; set; }
    }
}
