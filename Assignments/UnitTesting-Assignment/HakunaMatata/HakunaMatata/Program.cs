using HakunaMatata.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HakunaMatata.Models;
using HakunaMatata.Strategies;
using HakunaMatata.Repositories;
using HakunaMatata.Services;

var usersRepository = new UserRepository(new List<User>());
usersRepository.AddRange(new List<User>
{
    new User
    {
        Id = 1,
        Email = "dean.crainic@gmail.com",
        Password = "password123",
        FirstName = "Dean",
        LastName = "Alexandru"
    },
    new User
    {
        Id = 2,
        Email = "anamaghear@gmail.com",
        Password = "password1234",
        FirstName = "Ana",
        LastName = "Maghear"
    },
    new User
    {
        Id = 3,
        Email = "serban.alexandru@gmail.com",
        Password = "password",
        FirstName = "Alexandru",
        LastName = "Serban"
    },
    new User
    {
        Id = 4,
        Email = "tocai.raul@yahoo.com",
        Password = "parola231",
        FirstName = "Raul",
        LastName = "Tocai"
    },
    new User
    {
        Id = 5,
        Email = "snowtheblackdog@gmail.com",
        Password = "woof123",
        FirstName = "Snow",
        LastName = "The Black Dog"
    }
});

var propertiesRepository = new Repository<Property>(new List<Property>());
propertiesRepository.AddRange(new List<Property>
{
    new Property
    {
        Id = 1,
        Owner = usersRepository.Get(0),
        Name = "City Center Apartment",
        MaxGuests = 5,
        Address = "Piata Unirii, Nr. 34, Ap. 2, Timisoara, Timis, Romania",
        Price = 450
    },
    new Property
    {
        Id = 2,
        Owner = usersRepository.Get(4),
        Name = "House with a big yard",
        Description = "A big house, with a large yard",
        MaxGuests = 12,
        Address = "Strada Valea Cheii, Nr. 12, Poiana Brasov, Brasov, Romania",
        Price = 2200
    },
    new Property
    {
        Id = 3,
        Owner = usersRepository.Get(2),
        Name = "Cozy one room apartment",
        MaxGuests = 2,
        Address = "Aleea FC Ripensia, Nr. 6, Ap. 34, Timisoara, Timis, Romania",
        Price = 200
    },
    new Property
    {
        Id = 4,
        Owner = usersRepository.Get(1),
        Name = "Garden House",
        MaxGuests = 8,
        Address = "Via dei Lavatoi, Nr. 8, Florence, Tuscany, Italy",
        Price = 1500
    }
});

var reservationsRepository = new Repository<Reservation>(new List<Reservation>());
reservationsRepository.AddRange(new List<Reservation>
{
    new Reservation
    {
        Id = 1,
        Client = usersRepository.Get(0),
        Owner = usersRepository.Get(1),
        CheckinDate = new DateTime(2022, 4, 22),
        CheckoutDate = new DateTime(2022, 5, 2),
        GuestsNumber = 8,
        TotalPrice = 15000
    },
    new Reservation
    {
        Id = 2,
        Client = usersRepository.Get(3),
        Owner = usersRepository.Get(0),
        CheckinDate = new DateTime(2022, 4, 23),
        CheckoutDate = new DateTime(2022, 4, 26),
        GuestsNumber = 4,
        TotalPrice = 450 * 3
    },
    new Reservation
    {
        Id = 3,
        Client = usersRepository.Get(4),
        Owner = usersRepository.Get(0),
        CheckinDate = new DateTime(2022, 4, 27),
        CheckoutDate = new DateTime(2022, 5, 4),
        GuestsNumber = 4,
        TotalPrice = 450 * 7
    },
    new Reservation
    {
        Id = 4,
        Client = usersRepository.Get(1),
        Owner = usersRepository.Get(4),
        CheckinDate = new DateTime(2022, 4, 23),
        CheckoutDate = new DateTime(2022, 5, 3),
        GuestsNumber = 4,
        TotalPrice = 22000
    }
});

var userServices = new UserServices(usersRepository);

int userNumber = -1;
bool loggedIn = false;
int option;

do
{
    Console.WriteLine("Search as a guest = 0,\nLog in = 1,\nRegister = 2");
    option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 0:
            break;

        case 1:
            Console.WriteLine("Email:");
            var emailLogin = Console.ReadLine();
            Console.WriteLine("Password:");
            var passwordLogin = Console.ReadLine();

            loggedIn = userServices.LogIn(emailLogin, passwordLogin);
            if (loggedIn == false)
                Console.WriteLine("Log in failed");
            else
            { 
                Console.WriteLine("You're now logged in");
                userNumber = usersRepository.IndexOf(emailLogin);
            }
            break;

        case 2:
            Console.WriteLine("Email");
            var emailRegister = Console.ReadLine();
            Console.WriteLine("Password");
            var passwordRegister = Console.ReadLine();
            Console.WriteLine("First name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            var lastName = Console.ReadLine();

            loggedIn = userServices.Register(emailRegister, passwordRegister, firstName, lastName);
            if (loggedIn == false)
                Console.WriteLine("Email already registered");
            else
            {
                Console.WriteLine("You're now logged in");
                userNumber = usersRepository.IndexOf(emailRegister);
            }
            break;
    }
} while (option != 0 && loggedIn == false);

Console.WriteLine("Search for your desired city:");
var searchedLocation = Console.ReadLine();

var propertiesServices = new PropertiesServices(propertiesRepository);
var foundProperties = propertiesServices.SearchProperties(searchedLocation);

Console.WriteLine("Filter by price range: no = 0, yes = 1");
int filterOption = int.Parse(Console.ReadLine());

FilterContext filterStrategy;
switch (filterOption) {
    case 1:
        Console.WriteLine("What is the price range? Enter lower price first.");
        double lowerPrice = double.Parse(Console.ReadLine());
        double higerPrice = double.Parse(Console.ReadLine());

        filterStrategy = new FilterContext(new FilterByPriceRangeStrategy(lowerPrice, higerPrice));
        foundProperties = filterStrategy.FilterProperties(foundProperties);
        break;

    default:
        break;
}

Console.WriteLine("Sort by price: descending = 0, ascending = 1");
int sortOption = int.Parse(Console.ReadLine());

SortContext sortStrategy;
switch (sortOption)
{
    case 0:
        sortStrategy = new SortContext(new SortByPriceDescendingStrategy());
        foundProperties = sortStrategy.SortProperties(foundProperties);
        break;

    case 1:
        sortStrategy = new SortContext(new SortByPriceAscendingStrategy());
        foundProperties = sortStrategy.SortProperties(foundProperties);
        break;

    default:
        break;
}

foreach (var property in foundProperties)
{
    Console.WriteLine(property.Id);
    Console.WriteLine(property);
}

Console.WriteLine("Which property do you want to reserve?");
int propertyId;
propertyId = int.Parse(Console.ReadLine());

if (loggedIn == false)
{
    do
    {
        Console.WriteLine("Log in = 0,\nRegister = 1");
        option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 0:
                Console.WriteLine("Email:");
                var emailLogin = Console.ReadLine();
                Console.WriteLine("Password:");
                var passwordLogin = Console.ReadLine();

                loggedIn = userServices.LogIn(emailLogin, passwordLogin);
                if (loggedIn == false)
                    Console.WriteLine("Log in failed");
                else
                {
                    Console.WriteLine("You're now logged in");
                    userNumber = usersRepository.IndexOf(emailLogin);
                }
                break;
   
            case 1:
                Console.WriteLine("Email");
                var emailRegister = Console.ReadLine();
                Console.WriteLine("Password");
                var passwordRegister = Console.ReadLine();
                Console.WriteLine("First name:");
                var firstName = Console.ReadLine();
                Console.WriteLine("Last name:");
                var lastName = Console.ReadLine();

                loggedIn = userServices.Register(emailRegister, passwordRegister, firstName, lastName);
                if (loggedIn == false)
                    Console.WriteLine("Email already registered");
                else
                {
                    Console.WriteLine("You're now logged in");
                    userNumber = usersRepository.IndexOf(emailRegister);
                }
                break;

            default:
                Console.WriteLine("Wrong option");
                break;
        }
    } while (option != 0 && loggedIn == false);
}

Console.WriteLine("Which period would you like to reserve? Enter yyyy-mm-dd");

DateTime checkin = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
DateTime checkout = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);

Console.WriteLine("How many guests?");
int guests = int.Parse(Console.ReadLine());

var reservationService = new ReservationServices(reservationsRepository, propertiesRepository);
bool isReserved;

foreach (var reservation in reservationsRepository)
{
    Console.WriteLine(reservation.Id);
}

isReserved = reservationService.
    MakeReservation(usersRepository.ElementAt(userNumber), propertiesServices.FindProperty(propertyId).Owner,
    propertyId, checkin, checkout, guests);

if (isReserved == true)
    Console.WriteLine("Your reservation was added");
else
    Console.WriteLine("Reservation failed");

foreach (var reservation in reservationsRepository)
{
    Console.WriteLine(reservation.Id);
}