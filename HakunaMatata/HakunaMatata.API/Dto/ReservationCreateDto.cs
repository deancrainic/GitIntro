using HakunaMatata.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace HakunaMatata.API.Dto
{
    public class ReservationCreateDto
    {
        [Required]
        public int PropertyId { get; set; }
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
