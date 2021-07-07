using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KaraokePayment.DAO.Interface
{
    public interface IDAO<T>
    {
        void Add(T entity);

        Task Update(T entity);

        void Delete(T entity);

        Task<T> GetById(int id);

        Task<IQueryable<T>> GetAll();
    }
}
