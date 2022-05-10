namespace HakunaMatata.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public User Client { get; set; }
        public Property Property { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int GuestsNumber { get; set; }
        public double TotalPrice { get; set; }

        public Reservation() {}
    }
}