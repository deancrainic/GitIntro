using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class CarEqualityComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x.Brand.Equals(y.Brand) && x.Model.Equals(y.Model);
        }

        public int GetHashCode(Car obj)
        {
            return obj.Brand.GetHashCode() ^ obj.Model.GetHashCode();
        }
    }
}
