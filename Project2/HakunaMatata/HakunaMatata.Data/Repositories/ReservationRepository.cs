using HakunaMatata.Core.Abstractions;
using HakunaMatata.Core.Models;
using Microsoft.EntityFrameworkCore;
using HakunaMatata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Data.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(HakunaMatataContext ctx) : base(ctx) { }
        public async override Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _dbSet.Include(r => r.Property).ToListAsync();
        }

        public override IEnumerable<Reservation> GetAll()
        {
            return _dbSet.Include(r => r.Property).ToList();
        }

        public async override Task<Reservation> GetByIdAsync(int id)
        {
            var reservation = await _dbSet.Include(r => r.Property).SingleOrDefaultAsync(u => u.ReservationId == id);

            return reservation;
        }

        public override Reservation GetById(int id)
        {
            var reservation = _dbSet.Include(r => r.Property).SingleOrDefault(u => u.ReservationId == id);

            return reservation;
        }
    }
}
