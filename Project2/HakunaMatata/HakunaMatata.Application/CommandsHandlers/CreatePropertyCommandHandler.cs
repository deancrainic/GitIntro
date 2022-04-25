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
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Property>
    {
        private IUnitOfWork _uow;

        public CreatePropertyCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Property> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = new Property
            {
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                MaxGuests = request.MaxGuests,
                Price = request.Price
            };

            await _uow.PropertyRepository.AddAsync(property);
            await _uow.SaveAsync();

            return property;
        }
    }
}
