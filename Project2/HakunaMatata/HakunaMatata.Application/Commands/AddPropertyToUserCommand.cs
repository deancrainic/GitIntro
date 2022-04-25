using HakunaMatata.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Application.Commands
{
    public class AddPropertyToUserCommand : IRequest<User>
    {
        public int UserId { get; set; }
        public int PropertyId { get; set; }
    }
}
