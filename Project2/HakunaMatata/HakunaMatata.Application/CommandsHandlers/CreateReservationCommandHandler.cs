using HakunaMatata.Application.Commands;
using HakunaMatata.Application.Exceptions;
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
            if (_uow.PropertyRepository.GetById(request.PropertyId) == null)
                throw new IdNotExistentException("Property ID doesn't exist");

            if (!_uow.ReservationRepository.CheckDates(request.CheckinDate, request.CheckoutDate, request.PropertyId))
                throw new InvalidDatesException("Property is already reserved in this period");

            if (request.CheckinDate > request.CheckoutDate)
                throw new InvalidDatesException("Checkin date can't be later than checkoutdate");

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
