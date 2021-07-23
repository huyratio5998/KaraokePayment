using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int Id { get; set; }
        public string MaHH { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime HanSuDung { get; set; }
        public string HangHoaImage { get; set; }
        public ICollection<ThemHangHoa> ThemHangHoa { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
