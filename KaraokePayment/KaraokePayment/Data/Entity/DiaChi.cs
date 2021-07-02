using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    [Table("DiaChi")]
    public class DiaChi
    {
        [Key]
        public int Id { get; set; }
        public string Huyen { get; set; }
        public string Tinh { get; set; }
    }
}
