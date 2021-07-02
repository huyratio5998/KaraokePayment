using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    [Table("BookPhongOrder")]
    public class BookPhongOrder
    {
        [Key]
        public int Id { get; set; }
        public decimal TongTT { get; set; }
        public string TrangThai { get; set; }

        [ForeignKey("KhachHangId")]
        public string KhachHangId { get; set; }
        public KhachHang KhachHang { get; set; }
        [ForeignKey("NhanVienAdminCaLV")]
        public int NhanVienAdminCaLV { get; set; }
        public NhanVienCaLV NhanVienCaLV { get; set; }
    }
}
