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
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Reservation>
    {
        private IUnitOfWork _uow;

        public GetReservationByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Reservation> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _uow.ReservationRepository.GetByIdAsync(request.ReservationId);
        }
    }
}
