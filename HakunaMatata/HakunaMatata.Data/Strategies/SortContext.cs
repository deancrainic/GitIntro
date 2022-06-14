using HakunaMatata.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakunaMatata.Data.Strategies
{
    public class SortContext
    {
        private readonly ISortStrategy _strategy;

        public SortContext(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public IEnumerable<Property> SortProperties(IEnumerable<Property> properties)
        {
            if (_strategy == null)
            {
                //Console.WriteLine("No strategy");
                return new List<Property>();
            }
            else
                return _strategy.SortProperties(properties);
        }
    }
}
