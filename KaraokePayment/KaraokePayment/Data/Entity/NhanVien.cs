using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    public class NhanVien : ThanhVien
    {
        public string MaNV { get; set; }
        public decimal Luong { get; set; }
        public DateTime NgayTao { get; set; }
        public string LoaiNV { get; set; }

        public ICollection<NhanVienCaLV> NhanVienCaLv{ get; set; }
    }
}
