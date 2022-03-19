using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class ElectricCar : Car
    {
        public int BatteryAutonomy { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", {BatteryAutonomy}";
        }
    }
}
