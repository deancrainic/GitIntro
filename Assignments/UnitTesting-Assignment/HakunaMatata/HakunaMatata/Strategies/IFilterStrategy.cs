using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public interface IFilterStrategy
    {
        IEnumerable<Property> FilterProperties(IEnumerable<Property> properties);
    }
}
