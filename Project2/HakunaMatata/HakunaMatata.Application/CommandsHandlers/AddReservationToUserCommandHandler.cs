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
    public class AddReservationToUserCommandHandler : IRequestHandler<AddReservationToUserCommand, User>
    {
        private IUnitOfWork _uow;

        public AddReservationToUserCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> Handle(AddReservationToUserCommand request, CancellationToken cancellationToken)
        {
            var user = _uow.UserRepository.GetById(request.UserId);
            var reservation = _uow.ReservationRepository.GetById(request.ReservationId);

            user.Reservations.Add(reservation);
            _uow.UserRepository.Update(user);

            await _uow.SaveAsync();

            return user;
        }
    }
}
