using HakunaMatata.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Application.Commands
{
    public class DeleteReservationCommand : IRequest<Reservation>
    {
        public int ReservationId { get; set; }
    }
}
