using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KaraokePayment.Data.Entity
{
    public class ThanhVien : IdentityUser
    {
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CMT { get; set; }
        public string DiaChiChiTiet { get; set; }
        public DiaChi DiaChi { get; set; }
    }
}
