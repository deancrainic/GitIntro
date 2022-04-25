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
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, Property>
    {
        private IUnitOfWork _uow;

        public UpdatePropertyCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Property> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var updatedProperty = new Property
            {
                PropertyId = request.PropertyId,
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                MaxGuests = request.MaxGuests,
                Price = request.Price
            };

            _uow.PropertyRepository.Update(updatedProperty);
            await _uow.SaveAsync();

            return updatedProperty;
        }
    }
}
