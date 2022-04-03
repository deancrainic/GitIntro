using HakunaMatata.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HakunaMatata.Models;
using HakunaMatata.Strategies;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

//app.Run();

IEnumerable<UserModel> PopulateUsersList()
{
    List<UserModel> users = new List<UserModel>
    {
        new UserModel
        {
            Id = 1,
            Email = "dean.crainic@gmail.com",
            FirstName = "Dean",
            LastName = "Crainic",
            Password = "password123"
        },
        new UserModel
        {
            Id = 2,
            Email = "tocairaul@gmail.com",
            FirstName = "Raul",
            LastName = "Tocai",
            Password = "password123"
        },
        new UserModel
        {
            Id = 3,
            Email = "anamaghear@gmail.com",
            FirstName = "Ana",
            LastName = "Crainic",
            Password = "password321"
        },
        new UserModel
        {
            Id = 4,
            Email = "alexandru-b.serban@student.upt.ro",
            FirstName = "Alexandru",
            LastName = "Serban",
            Password = "parola2"
        },
        new UserModel
        {
            Id = 5,
            Email = "mircea.anghelescu@gmail.com",
            FirstName = "Mircea",
            LastName = "Anghelescu",
            Password = "parola3"
        }
    };

    return users;
}

var users = PopulateUsersList();

IEnumerable<PropertyModel> PopulatePropertiesList()
{
    List<PropertyModel> properties = new List<PropertyModel>
    {
        new PropertyModel
        {
            Id = 1,
            Owner = users.ElementAt(0),
            Name = "City Center Home",
            Description = "Cool house",
            MaxGuests = 6,
            Address = "Str. Gheorghe Lazar, Nr. 7, Ap. 12, Timisoara, Timis, Romania",
            Price = 240
        },
        new PropertyModel
        {
            Id = 2,
            Owner = users.ElementAt(3),
            Name = "Suburban House",
            Description = "Lovely suburbun house",
            MaxGuests = 12,
            Address = "Calea Girocului, Nr. 14, Timisoara, Timis, Romania",
            Price = 150
        },
        new PropertyModel
        {
            Id = 3,
            Owner = users.ElementAt(1),
            Name = "Modern Apartment near City Center",
            MaxGuests = 4,
            Address = "Bv. Take Ionescu, Nr. 7, Ap. 33, Timisoara, Timis, Romania",
            Price = 270
        }
    };

    return properties;
}

var properties = PopulatePropertiesList();

IEnumerable<ReservationModel> MakeReservations()
{
    var reservations = new List<ReservationModel>
    {
        new ReservationModel
        {
            Id = 1,
            Client = users.ElementAt(0),
            Owner = users.ElementAt(1),
            CheckinDate = new DateOnly(2022, 4, 22),
            CheckoutDate = new DateOnly(2022, 4, 30),
            GuestsNumber = 2,
            TotalPrice = 400
        },
        new ReservationModel
        {
            Id = 2,
            Client = users.ElementAt(3),
            Owner = users.ElementAt(2),
            CheckinDate = new DateOnly(2022, 5, 22),
            CheckoutDate = new DateOnly(2022, 5, 24),
            GuestsNumber = 3,
            TotalPrice = 340
        }
    };

    return reservations;
}

var reservations = MakeReservations();

var sortByPriceAscending = new SortByPriceAscendingStrategy();
var sortContext = new SortContext(sortByPriceAscending);

var sortedProps = sortContext.SortProperties(properties);

foreach (var prop in sortedProps)
{
    Console.WriteLine(prop);
}