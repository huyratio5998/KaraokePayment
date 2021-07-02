using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    [Table("CaLV")]
    public class CaLV
    {
        [Key]
        public int Id { get; set; }
        public string TenCa { get; set; }
        public double Tu { get; set; }
        public double Den { get; set; }
        public double HeSoLuong { get; set; }

        public ICollection<NhanVienCaLV> NhanVienCaLv { get; set; }

    }
}
