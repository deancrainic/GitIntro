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
    public class AddPropertyToUserCommandHandler : IRequestHandler<AddPropertyToUserCommand, User>
    {
        private IUnitOfWork _uow;

        public AddPropertyToUserCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> Handle(AddPropertyToUserCommand request, CancellationToken cancellationToken)
        {
            var property = _uow.PropertyRepository.GetById(request.PropertyId);
            if (property == null)
                throw new IdNotExistentException("Property ID doesn't exist");

            var user = _uow.UserRepository.GetById(request.UserId);
            if (user == null)
                throw new IdNotExistentException("User ID doesn't exist");

            user.Property = property;
            _uow.UserRepository.Update(user);
            await _uow.SaveAsync();
            return user;
        }
    }
}
