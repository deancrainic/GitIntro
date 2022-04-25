using HakunaMatata.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Application.Commands
{
    public class CreateImageCommand : IRequest<Image>
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
