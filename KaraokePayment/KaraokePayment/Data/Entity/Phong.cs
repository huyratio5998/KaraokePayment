using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    [Table("Phong")]
    public class Phong
    {
        [Key]
        public int Id { get; set; }
        public string TenPhong { get; set; }
        public string CoPhong { get; set; }
        public bool IsVIP { get; set; }
        public decimal Gia { get; set; }
        public string TrangThai { get; set; }

        public ICollection<BookPhongOrderPhong> BookphjoBookPhongOrderPhong{ get; set; }
    }
}
