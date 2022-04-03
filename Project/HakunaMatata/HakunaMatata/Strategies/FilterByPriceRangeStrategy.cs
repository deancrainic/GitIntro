using HakunaMatata.Models;

namespace HakunaMatata.Strategies
{
    public class FilterByPriceRangeStrategy : IFilterStrategy
    {
        private readonly double _priceLow;
        private readonly double _priceHigh;

        public FilterByPriceRangeStrategy(double priceLow, double priceHigh)
        {
            _priceLow = priceLow;
            _priceHigh = priceHigh;
        }

        public IEnumerable<PropertyModel> FilterProperties(IEnumerable<PropertyModel> properties)
        {
            return properties.Where(p => p.Price >= _priceLow && p.Price <= _priceHigh);
        }
    }
}
