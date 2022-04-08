using HakunaMatata.Models;
using HakunaMatata.Repositories;

namespace HakunaMatata.Services
{
    public class PropertiesServices
    {
        private Repository<Property> _properties;

        public PropertiesServices(Repository<Property> properties)
        {
            _properties = properties;
        }

        public IEnumerable<Property> SearchProperties(string searchedCity)
        {
            List<Property> foundProperties = new List<Property>();

            foreach (var property in _properties)
            {
                if (property.Address.Contains(searchedCity))
                {
                    foundProperties.Add(property);
                }
            }

            return foundProperties;
        }

        public Property FindProperty(int id)
        {
            foreach (var property in _properties)
            {
                if (property.Id == id)
                    return property;
            }

            return null;
        }
    }
}
