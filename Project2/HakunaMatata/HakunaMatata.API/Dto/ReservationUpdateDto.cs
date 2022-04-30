using System.ComponentModel.DataAnnotations;

namespace HakunaMatata.API.Dto
{
    public class ReservationUpdateDto
    {
        [Required]
        public DateTime CheckinDate { get; set; }
        [Required]
        public DateTime CheckoutDate { get; set; }
        [Required]
        public int GuestsNumber { get; set; }
        [Required]
        public double TotalPrice { get; set; }
    }
}
