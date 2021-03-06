using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.Models
{
    public class PhongViewModel
    {
        public PhongViewModel()
        {
            HangHoaSuDung = new List<HangHoaViewModel>();
        }
        public PhongInfoViewModel Phong { get; set; }
        public List<HangHoaViewModel> HangHoaSuDung { get; set; }
        public int BookPhongOrderPhongId { get; set; }
        public double ThoiGianSuDung { get; set; }
        public decimal TongTienSuDung { get; set; }
    }
}
