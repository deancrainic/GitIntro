using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public class SortByPriceAscendingStrategy : ISortStrategy
    {
        public IEnumerable<PropertyModel> SortProperties(IEnumerable<PropertyModel> properties)
        {
            return properties.OrderBy(p => p.Price);
        }
    }
}
