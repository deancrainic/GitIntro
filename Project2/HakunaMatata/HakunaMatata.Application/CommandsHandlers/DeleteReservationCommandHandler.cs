using HakunaMatata.Application.Commands;
using HakunaMatata.Core.Abstractions;
using HakunaMatata.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Application.CommandsHandlers
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Reservation>
    {
        private IUnitOfWork _uow;

        public DeleteReservationCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Reservation> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = _uow.ReservationRepository.DeleteById(request.ReservationId);
            await _uow.SaveAsync();

            return reservation;
        }
    }
}
