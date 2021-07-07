using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.DAO.Interface
{
    public interface IBookPhongOrderDAO : IDAO<BookPhongOrder>
    {
        Task<bool> CheckOrderFinish(int bookPhongOrderId);
    }
}
