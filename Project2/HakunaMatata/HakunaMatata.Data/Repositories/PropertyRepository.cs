using HakunaMatata.Core.Abstractions;
using HakunaMatata.Core.Models;
using HakunaMatata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Data.Repositories
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(HakunaMatataContext ctx) : base(ctx) { }
    }
}
