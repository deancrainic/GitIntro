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
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Reservation>
    {
        private IUnitOfWork _uow;

        public UpdateReservationCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Reservation> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var updatedReservation = new Reservation
            {
                ReservationId = request.ReservationId,
                Property = _uow.PropertyRepository.GetById(request.PropertyId),
                CheckinDate = request.CheckinDate,
                CheckoutDate = request.CheckoutDate,
                GuestsNumber = request.GuestsNumber,
                TotalPrice = request.TotalPrice
            };

            _uow.ReservationRepository.Update(updatedReservation);
            await _uow.SaveAsync();

            return updatedReservation;
        }
    }
}
