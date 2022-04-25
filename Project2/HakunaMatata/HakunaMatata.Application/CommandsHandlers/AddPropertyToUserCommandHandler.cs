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
                return null;

            var user = _uow.UserRepository.GetById(request.UserId);
            if (user == null)
                return null;

            user.Property = property;
            _uow.UserRepository.Update(user);
            await _uow.SaveAsync();
            return user;
        }
    }
}
