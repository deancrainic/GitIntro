using HakunaMatata.Application.Queries;
using HakunaMatata.Core.Abstractions;
using HakunaMatata.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Application.QueriesHandlers
{
    public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, Image>
    {
        private IUnitOfWork _uow;

        public GetImageByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Image> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
        {
            return await _uow.ImageRepository.GetByIdAsync(request.ImageId);
        }
    }
}
