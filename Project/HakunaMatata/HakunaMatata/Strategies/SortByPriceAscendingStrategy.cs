using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public class SortByPriceAscendingStrategy : ISortStrategy
    {
        public IEnumerable<Property> SortProperties(IEnumerable<Property> properties)
        {
            return properties.OrderBy(p => p.Price);
        }
    }
}
