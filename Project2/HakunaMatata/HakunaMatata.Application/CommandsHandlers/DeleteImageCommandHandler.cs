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
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, Image>
    {
        private IUnitOfWork _uow;

        public DeleteImageCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Image> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var image = _uow.ImageRepository.DeleteById(request.ImageId);
            await _uow.SaveAsync();

            return image;
        }
    }
}
