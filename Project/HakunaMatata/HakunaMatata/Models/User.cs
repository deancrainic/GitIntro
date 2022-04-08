namespace HakunaMatata.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public PropertyModel Property { get; set; }
        //public List<ReservationModel> PastReservations { get; set; }

        public User() {}
    }
}