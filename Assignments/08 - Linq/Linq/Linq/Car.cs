using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"{Brand}, {Model}, {HorsePower}, {Color}";
        }
    }
}
