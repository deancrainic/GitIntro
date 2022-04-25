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
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, Image>
    {
        private IUnitOfWork _uow;

        public CreateImageCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Image> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var image = new Image
            {
                Name = request.Name,
                Path = request.Path
            };

            await _uow.ImageRepository.AddAsync(image);
            await _uow.SaveAsync();

            return image;
        }
    }
}
