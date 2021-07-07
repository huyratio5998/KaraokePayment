using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;
using Microsoft.EntityFrameworkCore;

namespace KaraokePayment.DAO
{
    public class DAO<T> : IDAO<T> where  T: class
    {
        protected KaraokeDbContext _context;
        private DbSet<T> _dbSet;
        public DAO(KaraokeDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        #region

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Task.FromResult(_dbSet.Find(id));
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return await Task.FromResult(_dbSet.AsNoTracking<T>());
        }

        #endregion
    }
}
