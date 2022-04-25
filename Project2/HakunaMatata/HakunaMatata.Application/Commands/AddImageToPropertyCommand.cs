using HakunaMatata.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Application.Commands
{
    public class AddImageToPropertyCommand : IRequest<Property>
    {
        public int PropertyId { get; set; }
        public int ImageId { get; set; }
    }
}
