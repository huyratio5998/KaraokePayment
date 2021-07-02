using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    [Table("ThemHangHoa")]
    public class ThemHangHoa
    {
        [Key]
        public int Id { get; set; }
        public int SoLuong{ get; set; }

        [ForeignKey("BookPhongOrderPhongId")]
        public int BookPhongOrderPhongId { get; set; }
        public BookPhongOrderPhong BookPhongOrderPhong{ get; set; }
        [ForeignKey("HangHoaId")]
        public int HangHoaId { get; set; }
        public HangHoa HangHoa{ get; set; }
    }
}
