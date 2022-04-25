namespace HakunaMatata.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Property Property { get; set; }
        public List<Reservation> PastReservations { get; set; }

        public User() {}
    }
}