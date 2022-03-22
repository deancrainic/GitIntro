using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal static class CarExtensions
    {
        public static IEnumerable<Car> Filter(this IEnumerable<Car> carList, Func<Car, bool> predicate)
        {
            foreach (var car in carList)
            {
                if(predicate(car))
                    yield return car;
            }
        }

        public static bool HasColor(this IEnumerable<Car> carList, string color)
        {
            foreach (var car in carList)
            {
                if(car.Color.Equals(color))
                    return true;
            }

            return false;
        }

        public static int CountCarsWhere(this IEnumerable<Car> carList, Func<Car, bool> predicate)
        {
            int count = 0;

            foreach (var car in carList)
            {
                if (predicate(car))
                    count++;
            }

            return count;
        }
    }
}
