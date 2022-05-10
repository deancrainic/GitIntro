using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public interface ISortStrategy
    {
        IEnumerable<Property> SortProperties(IEnumerable<Property> properties);
    }
}
