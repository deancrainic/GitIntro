using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public class SortByPriceDescendingStrategy : ISortStrategy
    {
        public IEnumerable<PropertyModel> SortProperties(IEnumerable<PropertyModel> properties)
        {
            return properties.OrderByDescending(p => p.Price);
        }
    }
}
