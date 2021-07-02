using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.DAO.Implement
{
    public class BookPhongOrderDAO : BaseDAO<BookPhongOrder> , IBookPhongOrderDAO
    {
        public async Task<bool> CheckOrderFinish(int bookPhongOrderId)
        {
            var order =await GetSingleById(bookPhongOrderId);
            if (order == null) return false;
            if (order.TrangThai.Equals("paid")) return true;
            return false;
        }
    }
}
