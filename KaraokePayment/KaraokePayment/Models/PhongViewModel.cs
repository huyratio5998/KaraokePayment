using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.Models
{
    public class PhongViewModel
    {
        public Phong Phong { get; set; }
        public List<HangHoaViewModel> HangHoaSuDung { get; set; }
    }
}
