using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public class FilterContext
    {
        private readonly IFilterStrategy _filterStrategy;

        public FilterContext(IFilterStrategy strategy)
        {
            _filterStrategy = strategy;
        }

        public IEnumerable<Property> FilterProperties(IEnumerable<Property> properties)
        {
            if (_filterStrategy == null)
            {
                Console.WriteLine("No strategy");
                return new List<Property>();
            }
            else
                return _filterStrategy.FilterProperties(properties);
        }
    }
}
