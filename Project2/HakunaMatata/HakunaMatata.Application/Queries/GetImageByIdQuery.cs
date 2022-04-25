using HakunaMatata.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Application.Queries
{
    public class GetImageByIdQuery : IRequest<Image>
    {
        public int ImageId { get; set; }
    }
}
