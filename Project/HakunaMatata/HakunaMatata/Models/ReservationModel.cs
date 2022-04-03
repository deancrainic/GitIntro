namespace HakunaMatata.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public UserModel Client { get; set; }
        public UserModel Owner { get; set; }
        public DateOnly CheckinDate { get; set; }
        public DateOnly CheckoutDate { get; set; }
        public int GuestsNumber { get; set; }
        public double TotalPrice { get; set; }

        public ReservationModel()
        {

        }
    }
}