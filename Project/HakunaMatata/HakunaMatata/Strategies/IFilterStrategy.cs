using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public interface IFilterStrategy
    {
        IEnumerable<PropertyModel> FilterProperties(IEnumerable<PropertyModel> properties);
    }
}
