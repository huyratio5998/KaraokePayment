using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    [Table("NhanVienCaLV")]
    public class NhanVienCaLV
    {
        [Key]
        public int Id { get; set; }
        public DateTime NgayLV { get; set; }

        [ForeignKey("NhanVienId")]
        public string NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; }
        [ForeignKey("CaLvId")]
        public int CaLvId { get; set; }
        public CaLV CaLv { get; set; }
        public ICollection<BookPhongOrder> BookPhongOrder { get; set; }
    }
}
