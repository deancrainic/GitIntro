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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HakunaMatataContext ctx) : base(ctx) { }
        public async override Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.Include(u => u.Property).Include(u => u.Reservations).ToListAsync();
        }

        public override IEnumerable<User> GetAll()
        {
            return _dbSet.Include(u => u.Property).Include(u => u.Reservations).ToList();
        }

        public async override Task<User> GetByIdAsync(int id)
        {
            var user = await _dbSet.Include(u => u.Property).Include(u => u.Reservations).SingleOrDefaultAsync(u => u.UserId == id);

            return user;
        }

        public override User GetById(int id)
        {
            var user = _dbSet.Include(u => u.Property).Include(u => u.Reservations).SingleOrDefault(u => u.UserId == id);

            return user;
        }

        public bool CheckEmail(string email)
        {
            if (_dbSet.Any(u => u.Email == email))
                return false;

            return true;
        }

        public bool CheckPassword(string password)
        {
            if (password.Length < 8)
                return false;

            if (password.All(c => !char.IsDigit(c)))
                return false;

            return true;
        }

        public User GetByIdNoTracking(int id)
        {
            var user = _dbSet.AsNoTracking().Include(u => u.Property).Include(u => u.Reservations).SingleOrDefault(u => u.UserId == id);

            return user;
        }
    }
}
