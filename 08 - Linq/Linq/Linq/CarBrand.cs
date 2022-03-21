using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class CarBrand
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public IEnumerable<string> ?CarModels { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Year}, {Country}";
        }
    }
}
