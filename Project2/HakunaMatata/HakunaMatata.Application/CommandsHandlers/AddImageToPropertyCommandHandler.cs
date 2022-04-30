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
    public class AddImageToPropertyCommandHandler : IRequestHandler<AddImageToPropertyCommand, Property>
    {
        private IUnitOfWork _uow;

        public AddImageToPropertyCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Property> Handle(AddImageToPropertyCommand request, CancellationToken cancellationToken)
        {
            var property = _uow.PropertyRepository.GetById(request.PropertyId);
            if (property == null)
                throw new IdNotExistentException("Property ID doesn't exist");

            var image = _uow.ImageRepository.GetById(request.ImageId);
            if (image == null)
                throw new IdNotExistentException("Image ID doesn't exist");

            property.Images.Add(image);
            _uow.PropertyRepository.Update(property);
            await _uow.SaveAsync();

            return property;
        }
    }
}
