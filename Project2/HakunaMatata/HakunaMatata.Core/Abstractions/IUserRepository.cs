using HakunaMatata.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Core.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllAsync();
        IEnumerable<User> GetAll();
        Task<User> GetByIdAsync(int id);
        User GetById(int id);
    }
}
