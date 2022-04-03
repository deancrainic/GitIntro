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

        public IEnumerable<PropertyModel> SortProperties(IEnumerable<PropertyModel> properties)
        {
            if (_strategy == null)
            {
                Console.WriteLine("No strategy");
                return new List<PropertyModel>();
            }
            else
                return _strategy.SortProperties(properties);
        }
    }
}
