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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private IUnitOfWork _uow;

        public GetUserByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _uow.UserRepository.GetByIdAsync(request.UserId);
        }
    }
}
