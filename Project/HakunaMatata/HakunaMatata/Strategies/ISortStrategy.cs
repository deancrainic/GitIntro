using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public interface ISortStrategy
    {
        IEnumerable<PropertyModel> SortProperties(IEnumerable<PropertyModel> properties);
    }
}
