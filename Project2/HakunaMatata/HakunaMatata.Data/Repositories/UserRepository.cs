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
    }
}
