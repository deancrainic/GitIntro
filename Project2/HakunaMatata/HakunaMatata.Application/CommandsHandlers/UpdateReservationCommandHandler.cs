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
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Reservation>
    {
        private IUnitOfWork _uow;

        public UpdateReservationCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Reservation> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = _uow.ReservationRepository.GetByIdNoTracking(request.ReservationId);
            if (toUpdate == null)
                throw new IdNotExistentException("Reservation ID doesn't exist");

            if (!_uow.ReservationRepository.CheckDates(request.CheckinDate, request.CheckoutDate, toUpdate.Property.PropertyId, toUpdate.ReservationId))
            {
                throw new InvalidDatesException("Property is already reserved in this period");
            }

            if (request.CheckinDate > request.CheckoutDate)
                throw new InvalidDatesException("Checkin date can't be later than checkoutdate");

            var property = toUpdate.Property;
            toUpdate = new Reservation
            {
                ReservationId = request.ReservationId,
                Property = property,
                CheckinDate = request.CheckinDate,
                CheckoutDate = request.CheckoutDate,
                GuestsNumber = request.GuestsNumber,
                TotalPrice = request.TotalPrice
            };

            _uow.ReservationRepository.Update(toUpdate);
            await _uow.SaveAsync();

            return toUpdate;
        }
    }
}
