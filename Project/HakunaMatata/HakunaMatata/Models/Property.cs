namespace HakunaMatata.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxGuests { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public List<Image> Images { get; set; }

        public Property() {}

        public override string ToString()
        {
            return $"Name: {Name}\nDescription: {Description}\nGuests: {MaxGuests}\nAddress: {Address}\nPrice: {Price}\n";
        }
    }
}