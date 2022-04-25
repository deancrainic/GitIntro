using HakunaMatata.Core.Abstractions;
using HakunaMatata.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private HakunaMatataContext _context;

        public UnitOfWork(HakunaMatataContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public IPropertyRepository PropertyRepository => new PropertyRepository(_context);

        public IReservationRepository ReservationRepository => new ReservationRepository(_context);

        public IImageRepository ImageRepository => new ImageRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
