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
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Reservation>
    {
        private IUnitOfWork _uow;

        public CreateReservationCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Reservation> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation
            {
                Property = _uow.PropertyRepository.GetById(request.PropertyId),
                CheckinDate = request.CheckinDate,
                CheckoutDate = request.CheckoutDate,
                GuestsNumber = request.GuestsNumber,
                TotalPrice = request.TotalPrice
            };

            await _uow.ReservationRepository.AddAsync(reservation);
            await _uow.SaveAsync();

            return reservation;
        }
    }
}
