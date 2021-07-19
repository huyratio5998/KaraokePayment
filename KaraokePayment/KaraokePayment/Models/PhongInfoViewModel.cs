using KaraokePayment.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Models
{
    public class PhongInfoViewModel
    {
        public PhongInfoViewModel()
        {

        }
        public PhongInfoViewModel(Phong phong)
        {
            Id = phong.Id;
            TenPhong = phong.TenPhong;
            CoPhong = phong.CoPhong;
            IsVIP = phong.IsVIP;
            Gia = phong.Gia;
            TrangThai = phong.TrangThai;
        }
        public int Id { get; set; }
        public string TenPhong { get; set; }
        public string CoPhong { get; set; }
        public bool IsVIP { get; set; }
        public decimal Gia { get; set; }
        public string TrangThai { get; set; }
    }
}
