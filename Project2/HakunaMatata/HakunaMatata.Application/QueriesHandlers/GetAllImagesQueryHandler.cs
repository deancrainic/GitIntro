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
    public class GetAllImagesQueryHandler : IRequestHandler<GetAllImagesQuery, IEnumerable<Image>>
    {
        private IUnitOfWork _uow;

        public GetAllImagesQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Image>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
        {
            return await _uow.ImageRepository.GetAllAsync();
        }
    }
}
