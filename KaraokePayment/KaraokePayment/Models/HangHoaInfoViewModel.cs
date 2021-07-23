using KaraokePayment.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Models
{
    public class HangHoaInfoViewModel
    {
        public HangHoaInfoViewModel()
        {

        }
        public HangHoaInfoViewModel(HangHoa hangHoa)
        {
            Id = hangHoa.Id;
            MaHH = hangHoa.MaHH;
            Ten= hangHoa.Ten;
            SoLuong= hangHoa.SoLuong;
            Gia= hangHoa.Gia;
            NgayNhap= hangHoa.NgayNhap;
            HanSuDung= hangHoa.HanSuDung;
            HangHoaImage = hangHoa.HangHoaImage;
        }
        public int Id { get; set; }
        public string MaHH { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime HanSuDung { get; set; }
        public string HangHoaImage { get; set; }
    }
}
