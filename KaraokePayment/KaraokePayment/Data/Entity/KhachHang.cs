using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Data.Entity
{
    public class KhachHang : ThanhVien
    {
        public string MaKH { get; set; }
        public bool IsVIP  { get; set; }

        public ICollection<BookPhongOrder> BookPhongOrder { get; set; }
    }
}
