using HakunaMatata.Models;

namespace HakunaMatata.Strategies
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
                Console.WriteLine("No strategy");
                return new List<Property>();
            }
            else
                return _strategy.SortProperties(properties);
        }
    }
}
