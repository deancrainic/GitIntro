namespace HakunaMatata.API.Dto
{
    public class ReservationGetForPropertyDto
    {
        public string Email { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}
