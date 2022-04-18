using HakunaMatata.Core.Abstractions;
using HakunaMatata.Core.Models;
using HakunaMatata.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected HakunaMatataContext _dbContext;
        protected DbSet<T> _dbSet;

        public Repository(HakunaMatataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void DeleteById(int id)
        {
            var toDelete = _dbSet.Find(id);

            _dbSet.Remove(toDelete);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T toUpdate)
        {           
            _dbSet.Update(toUpdate);
        }
    }
}
