using HakunaMatata.Models;
using HakunaMatata.Repositories;

namespace HakunaMatata.Services
{
    public class ReservationServices
    {
        private Repository<Reservation> _reservationRepository;
        private Repository<Property> _propertyRepository;

        public ReservationServices(Repository<Reservation> reservationRepository, Repository<Property> propertyRepository)
        {
            _reservationRepository = reservationRepository;
            _propertyRepository = propertyRepository;
        }

        public bool MakeReservation(User client, User owner, int propertyId, DateTime checkin, DateTime checkout, int guests)
        {
            
            foreach (var reservation in _reservationRepository)
            {
                if (reservation.Owner.Id == owner.Id)
                    if (checkin < reservation.CheckoutDate || (checkout > reservation.CheckinDate && checkin < reservation.CheckinDate) || 
                        _propertyRepository.ElementAt(propertyId).MaxGuests < guests)
                        return false;
            }

            _reservationRepository.Add(new Reservation
            {
                Id = _reservationRepository.Last().Id + 1,
                Client = client,
                Owner = owner,
                CheckinDate = checkin,
                CheckoutDate = checkout,
                GuestsNumber = guests,
                TotalPrice = (checkout - checkin).TotalDays * _propertyRepository.ElementAt(propertyId).Price
            });

            return true;
        }
    }
}
