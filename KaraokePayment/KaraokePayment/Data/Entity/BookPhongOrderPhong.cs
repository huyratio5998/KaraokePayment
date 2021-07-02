using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    [Table("BookPhongOrderPhong")]
    public class BookPhongOrderPhong
    {
        [Key]
        public int Id { get; set; }
        public int NhanVienBook1Id { get; set; }
        public int NhanVienBook2Id { get; set; }
        public DateTime ThoiGianBatDau{ get; set; }
        public DateTime ThoiGianKetThuc{ get; set; }
        public string PhuongThucTT { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
        public decimal TongTien { get; set; }

        [ForeignKey("BookPhongOrderId")]
        public int BookPhongOrderId { get; set; }
        public BookPhongOrder BookPhongOrder{ get; set; }
        [ForeignKey("PhongId")]
        public int PhongId { get; set; }
        public Phong Phong{ get; set; }
        public ICollection<ThemHangHoa> ThemHangHoa { get; set; }

    }
}
