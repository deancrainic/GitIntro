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
    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, Property>
    {
        private IUnitOfWork _uow;

        public DeletePropertyCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Property> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            var toDelete = _uow.PropertyRepository.DeleteById(request.PropertyId);
            
            await _uow.SaveAsync();

            return toDelete;
        }
    }
}
