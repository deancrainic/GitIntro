using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public class SortByPriceDescendingStrategy : ISortStrategy
    {
        public IEnumerable<Property> SortProperties(IEnumerable<Property> properties)
        {
            return properties.OrderByDescending(p => p.Price);
        }
    }
}
