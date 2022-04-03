namespace HakunaMatata.Models
{
    public class PropertyModel
    {
        public int Id { get; set; }
        public UserModel Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxGuests { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public List<ImageModel> Images { get; set; }

        public PropertyModel()
        {

        }

        public override string ToString()
        {
            return Name + "\n" + Price;
        }
    }
}